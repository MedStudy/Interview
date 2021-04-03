using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public class petsRepository : Ipets
  {
    private readonly MedDbContext _context;
    public petsRepository(MedDbContext context)
    {
      _context = context;
    }
    public Pets createpet(Pets data)
    {
      try
      {
        _context.Pets.Add(data);
        _context.SaveChanges();
        return data;
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }

    public string deletepet(string id)
    {
      try
      {
        var pet = _context.Pets.Where(x => x.id == Convert.ToInt32(id)).First();
        _context.Pets.Remove(pet);
        _context.SaveChanges();
        return id;
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }

    public IEnumerable<PetsList> getAllpets()
    {
      try
      {
        var result = from a in _context.Owners
                     join c in _context.Pets on a.id equals c.owner_id
                     select new PetsList()
                     {
                       id = c.id,
                       age = c.age,
                       name = c.name,
                       owner_id = c.owner_id,
                       owner_name = (a.first_name + " " + a.last_name),
                       type = c.type
                     };
        return result;
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }

    public PetsList getpets(string id)
    {
      try
      {
        var result = from a in _context.Owners
                     join c in _context.Pets on a.id equals c.owner_id
                     where c.id == Convert.ToInt32(id)
                     select new PetsList()
                     {
                       id = c.id,
                       age = c.age,
                       name = c.name,
                       owner_id = c.owner_id,
                       owner_name = (a.first_name + " " + a.last_name),
                       type = c.type
                     };
        return result.First();
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }

    public Pets updatepet(Pets data)
    {
      try
      {
        _context.Pets.Update(data);
        _context.SaveChanges();
        return data;
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }
  }
}
