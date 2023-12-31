﻿using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.SkillDTOs;
using API_university_labor_exchange.Services.Interfaces;
using AutoMapper;

namespace API_university_labor_exchange.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public ICollection<ReadSkillDTO> GetSkillsForForm()
        {
            var skills = _skillRepository.GetSkillsForForm();
            return _mapper.Map<ICollection<ReadSkillDTO>>(skills);
        }
        public ReadSkillDTO? GetSkill(int skillId)
        {
            var skill = _skillRepository.GetSkill(skillId);
            return _mapper.Map<ReadSkillDTO>(skill);

        }

        public void AddSkill(CreateSkillDTO createSkillDTO)
        {
            Skill newSkill = new Skill();
            newSkill.SkillName = createSkillDTO.SkillName;
            newSkill.State = true;

            _skillRepository.AddSkill(newSkill);
            _skillRepository.SaveChanges();

        }

        public CreateSkillDTO UpdateSkill(CreateSkillDTO updateSkill)
        {
            Skill modifiedSkill = _skillRepository.UpdateSkill(updateSkill);

            return _mapper.Map<CreateSkillDTO>(modifiedSkill);

        }

        public void DeleteSkill(int skillId)
        {

            _skillRepository.DeleteSkill(skillId);
            _skillRepository.SaveChanges();

        }
    }
}
