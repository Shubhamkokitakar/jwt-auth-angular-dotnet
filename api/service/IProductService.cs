using api.Models;
using System.Collections.Generic;

namespace api.Services
{
    public interface IProductService
    {
        List<PlayingWithNeonData> GetAllData();
        float ProcessValue(PlayingWithNeonData data);
        void InsertData(PlayingWithNeonData data);
    }
}
