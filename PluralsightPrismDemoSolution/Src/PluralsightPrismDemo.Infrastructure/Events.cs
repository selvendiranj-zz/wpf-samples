﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace PluralsightPrismDemo.Infrastructure
{
    public class PersonUpdatedEvent : PubSubEvent<string> { }

}