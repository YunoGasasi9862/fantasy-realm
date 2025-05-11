using MediatR;
using Microsoft.EntityFrameworkCore;
using App.FantasyRealm.PersonalityAnswer;
using App.FantasyRealm.PersonalityType;
using App.FantasyRealm.QuestionChoice;
using App.FantasyRealm.Domain;
using System.Linq;

namespace App.FantasyRealm.FantasyUserPersonalityAssociation.Query
{
    public class CalculateUserPersonalityQuery : IRequest<CalculateUserPersonalityResponse>
    {
        public int UserId { get; set; }
        public List<int> QuestionChoiceIds { get; set; }
    }

    public class CalculateUserPersonalityResponse
    {
        public string Code { get; set; }
        public List<string> TraitNames { get; set; }
    }

    public class CalculateUserPersonalityQueryHandler : IRequestHandler<CalculateUserPersonalityQuery, CalculateUserPersonalityResponse>
    {
        private readonly FantasyRealmDBContext _db;

        public CalculateUserPersonalityQueryHandler(FantasyRealmDBContext db)
        {
            _db = db;
        }

        public async Task<CalculateUserPersonalityResponse> Handle(CalculateUserPersonalityQuery request, CancellationToken cancellationToken)
        {
            var personalityTypes = await _db.PersonalityTypes
                .Where(pt => pt.Id <= 10)
                .ToDictionaryAsync(pt => pt.Id, pt => new { pt.Name, pt.Description }, cancellationToken);

            var answerMappings = await _db.PersonalityAnswers
                .Where(pa => request.QuestionChoiceIds.Contains(pa.ChoiceId))
                .ToListAsync(cancellationToken);

            var traitCountsByGroup = new Dictionary<int, Dictionary<int, int>>();

            foreach (var answer in answerMappings)
            {
                var groupIndex = (answer.QuestionId - 1) / 5; // groups: 0-4 -> 0, 5-9 -> 1, ..., 20-24 -> 4

                if (!traitCountsByGroup.ContainsKey(groupIndex))
                    traitCountsByGroup[groupIndex] = new Dictionary<int, int>();

                if (!traitCountsByGroup[groupIndex].ContainsKey(answer.PersonalityTypeId))
                    traitCountsByGroup[groupIndex][answer.PersonalityTypeId] = 0;

                traitCountsByGroup[groupIndex][answer.PersonalityTypeId]++;
            }

            var selectedTraits = new List<string>();
            var code = "";

            foreach (var group in traitCountsByGroup.OrderBy(g => g.Key))
            {
                var max = group.Value.OrderByDescending(kvp => kvp.Value).FirstOrDefault();
                var typeId = max.Key;

                if (personalityTypes.TryGetValue(typeId, out var trait))
                {
                    selectedTraits.Add(trait.Description);
                    code += trait.Name; // Name holds the 1-letter code
                }
            }

            return new CalculateUserPersonalityResponse
            {
                Code = code,
                TraitNames = selectedTraits
            };
        }
    }
}
