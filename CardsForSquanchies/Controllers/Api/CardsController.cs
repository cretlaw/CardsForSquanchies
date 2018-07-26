using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CardsForSquanchies.Models;

namespace CardsForSquanchies.Controllers.Api
{
    public class CardsController : ApiController
    {

        private ApplicationDbContext _context;

        public CardsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/cards
        public IHttpActionResult GetCards()
        {
            return Ok(_context.Cards.ToList());
        }

        //GET api/cards/1
        public IHttpActionResult GetCard(int id)
        {
            var card = _context.Cards.SingleOrDefault(c => c.Id == id);

            if (card == null)
                return NotFound();

            return Ok(card);
        }

        //POST api/cards
        [HttpPost]
        public IHttpActionResult CreateCard(Card card)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Cards.Add(card);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + card.Id), card);
        }

        //PUT api/cards/1
        [HttpPut]
        public IHttpActionResult UpdateCard(int id, Card card)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cardInDb = _context.Cards.SingleOrDefault(c => c.Id == id);

            if (cardInDb == null)
                return NotFound();

            cardInDb.Id = card.Id;
            cardInDb.FrontText = card.FrontText;
            cardInDb.BackText = card.BackText;
            cardInDb.CardCommand = card.CardCommand;

            _context.SaveChanges();

            return Ok();
        }


        //DELETE api/cards/1
        [HttpDelete]
        public IHttpActionResult DeleteCards(int id)
        {
            var cardInDb = _context.Cards.SingleOrDefault(c => c.Id == id);

            if (cardInDb == null)
                return NotFound();



            _context.Cards.Remove(cardInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
    
}
