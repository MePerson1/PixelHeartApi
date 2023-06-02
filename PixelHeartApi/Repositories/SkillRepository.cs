﻿using PixelHeartApi.Data;
using PixelHeartApi.Interfaces;
using PixelHeartApi.Models;

namespace PixelHeartApi.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private DatabaseContext context;
        public SkillRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public int Create(Skill skill)
        {
            context.Skills.Add(skill);
            context.SaveChanges();
            return skill.Id;
        }

        public bool Delete(int id)
        {
            var skillToDelete = context.Skills.Find(id);
            if (skillToDelete is null)
            { return false; }
            context.Skills.Remove(skillToDelete);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Skill> GetAll()
        {
            return context.Skills.ToList();
        }

        public ICollection<Skill> GetAllSkills()
        {
            throw new NotImplementedException();
        }

        public Skill? GetById(int id)
        {
            return context.Skills.FirstOrDefault(skill => skill.Id == id);
        }

        public ICollection<Skill> GetSkillByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetUserBySkillId(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Skill skill)
        {
            var skillToUpadet = context.Skills.Find(id);
            if (skillToUpadet is null)
            {
                return false;
            }
            skillToUpadet.Name = skill.Name;

            context.SaveChanges();

            return true;
        }
    }
}
