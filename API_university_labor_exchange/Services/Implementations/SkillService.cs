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

        public IEnumerable<ReadSkillDTO> GetAllSkills()
        {
            var skills = _skillRepository.GetAllSkills();
            return _mapper.Map<ICollection<ReadSkillDTO>>(skills);
        }
        public ReadSkillDTO? GetSkillBy(int skillId)
        {
            var skill = _skillRepository.GetSkillBy(skillId);
            return _mapper.Map<ReadSkillDTO>(skill);

        }
        public void AddSkill(CreateSkillDTO createSkillDTO)
        {
            var newSkill = _mapper.Map<Skill>(createSkillDTO);
            _skillRepository.AddSkill(newSkill);
            _skillRepository.SaveChanges();

        }
    }
}