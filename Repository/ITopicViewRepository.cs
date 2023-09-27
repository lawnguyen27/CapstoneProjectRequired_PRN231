using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ITopicViewRepository
    {
        IEnumerable<TopicView> GetTopicViews();
        void CreateTopicView(TopicView topic);
        void UpdateStatus(int Id);
    }
}
