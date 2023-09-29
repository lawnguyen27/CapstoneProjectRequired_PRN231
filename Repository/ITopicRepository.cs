using BusinessObjects.DTOs;
using BusinessObjects.DTOs.Request;
using BusinessObjects.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ITopicRepository
    {
        IEnumerable<TopicResponse> GetTopics();
        void CreateTopic(TopicRequest topic);
        void UpdateStatus(int Id);
    }
}
