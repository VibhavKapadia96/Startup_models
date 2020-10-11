using System;
using System.Collections.Generic;
using System.Text;

namespace Startup_models
{
    class Sub_topics
    {
        public virtual Topics Topics { get; set; }
        public int Sub_topic_Id { get; set; }
        public string Sub_topic_Name { get; set; }
    }
}
