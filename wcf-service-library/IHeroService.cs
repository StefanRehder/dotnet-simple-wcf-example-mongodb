using MongoDB.Bson;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HeroServiceContracts
{
    [ServiceContract]
    public interface IHeroService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "hero/{name}")]
        Hero GetHero(string name);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "hero/list")]
        Hero[] GetHeroList();

        [OperationContract]
        [WebInvoke(Method = "DELETE",
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "hero/{name}")]
        void DeleteHero(string name);

        [OperationContract]
        [WebInvoke(Method = "PUT",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "hero")]
        void PutHero(Hero hero);
    }

    [DataContract(Namespace = "")]
    public class Hero
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Strength { get; set; }

        [DataMember]
        public ObjectId _id { get; set; }
    }
}
