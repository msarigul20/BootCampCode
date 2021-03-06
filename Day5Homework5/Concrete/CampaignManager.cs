﻿using System;
using System.Collections.Generic;
using System.Text;
using Day5Homework5.Abstract;
using Day5Homework5.Entities;

namespace Day5Homework5.Concrete
{
    class CampaignManager : ICampaignService
    {
        List<Campaign> campaignList = new List<Campaign>();

        public void Add(Campaign campaign)
        {
            campaignList.Add(campaign);
            Console.WriteLine("'"+campaign.Name + "' campaign has been added in system");
        }

        public void ApplyDiscountToGame(Game game, Campaign campaign)
        {
            game.Price = game.Price - (game.Price*(campaign.Discount/100));
            Console.WriteLine(campaign.Discount + "% discount applied to " + game.Name + ".");
            Console.WriteLine("New price of "+game.Name+"is "+game.Price);
        }

        public void Delete(Campaign campaign)
        {
            campaignList.Remove(campaign);
            Console.WriteLine(campaign.Name + " campaign has been deleted in system");
        }

        public void GetCampaigns()
        {
           
            System.Console.WriteLine("**************** CAMPAIGN LİST ***************");
            foreach (var campaign in campaignList) {
                Console.WriteLine("Campaign ID: " + campaign.Id);
                Console.WriteLine("Campaign Name: " + campaign.Name);
                Console.WriteLine("Campaign Discount: " + campaign.Discount + "%");
                System.Console.WriteLine("------------");
            }
            System.Console.WriteLine("******************************************");
        }

        public void Update(Campaign campaign)
        {
            Console.WriteLine(campaign.Name + " campaign has been updated in system");
        }
    }
}
