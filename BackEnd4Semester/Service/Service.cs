﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace Service
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class Service : IService 
    {
        Player IService.getPlayer(string email)
        {
            throw new NotImplementedException();
        }

        Player getPlayer(String email)
        {
            return new Player();
        }
    }
}
