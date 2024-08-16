using ClothingPro.BusinessLayer.DTO;
using ClothingPro.Models;
namespace ClothingPro.BusinessLayer.Interface;

public interface IStockService
{
    List<StockDTO> GetAllStock();
    StockDTO GetStockById(int stId);
    StockDTO GetStockByBarcodeId(int? barcodeId);
    int CreateStock(StockDTO stockUI);
    bool DeleteStock(int stId);
    StockDTO GetAllKindOfStock();
    List<StockDTO> GetLatestDetail(string FromDate, string ToDate);
    List<StockMenuView> GetStockMenuList(string search);
}
