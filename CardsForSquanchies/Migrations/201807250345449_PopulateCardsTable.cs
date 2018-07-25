namespace CardsForSquanchies.Migrations
{
    using CardsForSquanchies.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;

    public partial class PopulateCardsTable : DbMigration 
    {
        public override void Up()
        {
            var CardsFront = JsonConvert.DeserializeObject<dynamic>(
                File.ReadAllText(@"C:\Users\wcarb\OneDrive\PERSONAL PROJECTS\JSONManipulator\front.json"));
            var Cardsback =
                JsonConvert.DeserializeObject<dynamic>(
                    File.ReadAllText(@"C:\Users\wcarb\OneDrive\PERSONAL PROJECTS\JSONManipulator\back.json"));

            List<Card> DeckOfCards = new List<Card>();
            for (int i = 0; i < 482; i++)
            {
                var myCard = new Card
                {
                    FrontText = CardsFront[i].frontText.ToString().Replace("'", "''"),
                    BackText = Cardsback[i].backText.ToString().Replace("'", "''"),
                    CardCommand = CardsFront[i].rule
                };
                DeckOfCards.Add(myCard);


            }

            foreach (var card in DeckOfCards)
            {
                Sql($"INSERT INTO CARDS (FrontText, BackText, CardCommand) VALUES ('{card.FrontText}','{card.BackText}', '{card.CardCommand}')");

            }
        }

        public override void Down()
        {
        }
    }
}
