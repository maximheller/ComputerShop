using NewComputerShop.Models;
using Microsoft.EntityFrameworkCore;
//using NuGet.Protocol.Core.Types;

namespace NewComputerShop.Data
{
    public class Repository : IRepository
    {
        private readonly ShopContext context; // field
        public Repository(ShopContext context)
        {
            this.context = context;            
        }

        public IEnumerable<Processor> Processors => context.Processors  // Property
            .Include(p => p.Manufacturer)
            .Include(p => p.Categories);

        //public IEnumerable<Processor> Processors // Property
        //{
        //    get
        //    {                
        //        return context.Processors
        //           .Include(p => p.Manufacturer)
        //           .Include(p => p.Categories);
        //    } 
        //}

        

        public IEnumerable<Ram> Rams => context.Rams.Include(p => p.Manufacturer);

        public IEnumerable<Manufacturer> Manufacturers => context.Manufacturers.Include(m => m.Processors);

        public IEnumerable<Category> Categories => context.Categories.Include(c => c.Processors);

        public IEnumerable<User> Users => context.Users;

        public IEnumerable<Order> Orders => context.Orders
            .Include(o => o.Orderlines)
            .ThenInclude(orderline => orderline.Product);


        public IEnumerable<Product> Products => context.Products;

        public IEnumerable<Orderline> Orderlines => context.Orderlines;

        public void Delete(Manufacturer manufacturer)
        {
            context.Manufacturers.Remove(manufacturer);
            context.SaveChanges();
        }

        public void Delete(Processor processor)
        { 
            context.Processors.Remove(processor);
            context.SaveChanges();
        }
        public void Add(Processor processor)
        {
            context.Processors.Add(processor);
            context.SaveChanges();
        }
        public void Update(Processor processor)
        {
            context.Processors.Update(processor);
            context.SaveChanges();
        }

        public void Update(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }

        public async void Delete(Ram ram)
        {
            context.Rams.Remove(ram);
            context.SaveChanges();
        }
        public void Add(Ram ram)
        {
            context.Rams.Add(ram);
            context.SaveChanges();
        }
        public void Update(Ram ram)
        {
            context.Rams.Update(ram);
            context.SaveChanges();
        }

        public void AddProcessorToCategory(int processorId, int categoryId)
        {           
            Func<Processor, bool> predicate = p => p.Id == processorId;
            Processor? processor = Processors.SingleOrDefault(predicate);           
            Category? category = Categories.SingleOrDefault(c => c.Id == categoryId); 

            if (category != null && processor != null)
            {
                category.Processors.Add(processor);
            }

            context.SaveChanges();
        }

        public void DeleteProcessorFromCategory(int processorId, int categoryId)
        {           
            Processor? processor = Processors.SingleOrDefault(p => p.Id == processorId);
            Category? category = Categories.SingleOrDefault(c => c.Id == categoryId);

            if (category != null && processor != null)
            {
                category.Processors.Remove(processor);
            }

            context.SaveChanges();
        }

        public void AddCategoriesToProcessor(int[] categoryIds, Processor processor)
        {
            foreach (Category category in Categories.ToArray()) // all categories  {1, 2, 3, 4};
            {
                if (categoryIds.Contains(category.Id))  // 1 3
                {
                    if (!processor.Categories.Contains(category))
                    {
                        processor.Categories.Add(category);                        
                    }
                }
                else // 2 4
                {
                    if (processor.Categories.Contains(category))
                    {
                        processor.Categories.Remove(category);
                    }
                }               
            }
            context.SaveChanges();
        }


        private void TestInit()
        {
            int x;
            // int y = x + 2; // error
            Order order = new Order { CreatedDate = DateTime.Now, UserId = 1};
            bool paid = order.Paid; // ok

        }



        public void AddProductToOrder(int productId, int userId)
        {
            Order? order = Orders.FirstOrDefault(o => !o.Paid && o.UserId == userId);

            if (order == null)
            {
                order = new Order 
                { 
                    CreatedDate = DateTime.Now, 
                    UserId = userId, 
                    Paid = false, 
                    Orderlines = new List<Orderline>() 
                };
                Add(order);
            }
          
            Orderline? orderline = order.Orderlines.FirstOrDefault(o => o.ProductId == productId);
            // Orderline? orderline = Orderlines.FirstOrDefault(o => o.OrderId == order.Id && o.ProductId == productId);

            if (orderline == null)
            {
                orderline = new Orderline { OrderId = order.Id, ProductId = productId, Quantity = 1};
                Add(orderline);
            }
            else
            {
                orderline.Quantity++;
                context.SaveChanges();
            }
        }

        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }


        public void Add(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void Add(Orderline orderline)
        {
            context.Orderlines.Add(orderline);
            context.SaveChanges();
        }




        //public void Login

        //public void AddProcessorToCategory(int processorId, int categoryId)
        //{
        //    // TODO 
        //    Func<Processor, bool> predicate = p => p.Id == processorId;
        //    Processor? processor = context.Processors.SingleOrDefault(predicate);

        //    Category? category = context.Categories.SingleOrDefault(c => c.Id == categoryId); // gamers

        //    if (category != null && processor != null)
        //    {
        //        CategoryProcessor categoryProcessor = new CategoryProcessor
        //        {
        //            CategoryId = categoryId, 
        //            ProcessorId = processorId 
        //        };
        //        context.CategoryProcessors.Add(categoryProcessor);
        //    }

        //    context.SaveChanges();


        //}


    }
}
