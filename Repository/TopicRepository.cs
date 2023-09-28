using BusinessObjects.DTOs;
using BusinessObjects.DTOs.Request;
using BusinessObjects.DTOs.Response;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TopicRepository : ITopicRepository
    {
        public void CreateTopic(TopicRequest topic) => TopicDAO.Instance.CreateTopic(topic);

        public IEnumerable<TopicResponse> GetTopics() => TopicDAO.Instance.GetTopics();

        public void UpdateStatus(int Id) => TopicDAO.Instance.UpdateStatus(Id);
    }
}
