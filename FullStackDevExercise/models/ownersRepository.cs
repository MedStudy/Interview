using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public class ownersRepository : Iowner
  {
    private readonly MedDbContext _context;
    public ownersRepository(MedDbContext context)
    {
      _context = context;
    }
    public owners createowner(owners data)
    {
      try
      {
        _context.Owners.Add(data);
        _context.SaveChanges();
        return data;
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }
    public owners getowners(string id)
    {
      try
      {
        var result = _context.Owners.First(x => x.id == Convert.ToInt32(id));
        return result;
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }
    public string deleteowner(string id)
    {
      try
      {
        var owner = _context.Owners.Where(x => x.id == Convert.ToInt32(id)).First();
        _context.Owners.Remove(owner);
        _context.SaveChanges();
        return id;
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }

    public IEnumerable<owners> getAllowners()
    {
      try
      {
        var result = _context.Owners.ToList();
        return result;
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }

    public owners updateowner(owners data)
    {
      try
      {
        _context.Owners.Update(data);
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
