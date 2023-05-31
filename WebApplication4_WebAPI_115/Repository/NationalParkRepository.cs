﻿using WebApplication4_WebAPI_115.Data;
using WebApplication4_WebAPI_115.Models;
using WebApplication4_WebAPI_115.Repository.IRepository;

namespace WebApplication4_WebAPI_115.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _context;
        public NationalParkRepository(ApplicationDbContext context)
        {
           _context = context;
        }
        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _context.NationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalParkId)
        {
            _context.NationalParks.Remove(nationalParkId);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
            return _context.NationalParks.Find(nationalParkId);

        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _context.NationalParks.ToList();
        }

        public bool NationalParkExists(int nationalParkId)
        {
           return _context.NationalParks.Any(np=>np.Id==nationalParkId);
        }

        public bool NationalParkExists(string nationalParkName)
        {
            return _context.NationalParks.Any(np => np.Name==nationalParkName);
        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
         _context.NationalParks.Update(nationalPark);
            return Save();
        }
    }
}
