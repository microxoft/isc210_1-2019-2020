using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PirataRPGModel;

namespace PirataRPGWebService.Controllers
{
    public class ValuesController : ApiController
    {
        PirataRPGDBEntities dbContext = new PirataRPGDBEntities();

        // GET api/values
        public IEnumerable<PongScores> Get()
        {
            return dbContext.PongScores.ToList();
        }

        // GET api/values/5
        public PongScores Get(int id)
        {
            return dbContext.PongScores.FirstOrDefault(ps => ps.Id == id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put([FromBody]PongScores newScore)
        {
            PongScores tmp = dbContext.PongScores.FirstOrDefault(ps => ps.Id == newScore.Id);
            if(tmp != null)
            {
                tmp.PlayerName = newScore.PlayerName;
                tmp.Score = newScore.Score;
            }
            else
            {
                tmp = new PongScores()
                {
                    PlayerName = newScore.PlayerName,
                    Score = newScore.Score
                };
                dbContext.PongScores.Add(tmp);
            }

            dbContext.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
