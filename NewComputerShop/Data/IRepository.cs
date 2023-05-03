using NewComputerShop.Models;

namespace NewComputerShop.Data
{
    public interface IRepository
    {

        IEnumerable<Processor> Processors { get; }
        IEnumerable<Ram> Rams { get; }
        IEnumerable<Manufacturer> Manufacturers { get; }
        IEnumerable<Category> Categories { get; }
        IEnumerable<User> Users { get; }
        IEnumerable<Order> Orders { get; }
        IEnumerable<Orderline> Orderlines { get; }

        void Add(Processor processor);
        void Add(Order order);
        void Add(Orderline orderline);
        void Add(Ram ram);
        void Add(User user);

        void Delete(Ram ram);
        void Delete(Processor processor);

        void Update(Ram ram);
        void Update(Processor processor);
        void Update(User user);

        void AddProcessorToCategory(int processorId, int categoryId);
        void DeleteProcessorFromCategory(int processorId, int categoryId);
        void AddCategoriesToProcessor(int[] categoryIds, Processor processor);
        void AddProductToOrder(int productId, int userId);

       
    }
}
