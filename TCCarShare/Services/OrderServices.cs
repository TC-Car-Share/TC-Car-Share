using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Data;
using TCCarShare.Entity.Response;
using TCCarShare.IServices;
using TCCarShare.Models;
using TCCarShare.ViewModels;

namespace TCCarShare.Services
{
    public class OrderServices : IServices<Order>
    {
        private readonly DataContext _context;

        public OrderServices(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Order.ToList();
        }

        public Order GetById(int id)
        {
            return _context.Order.Find(id);
        }

        public Order Add(Order newModel)
        {
            _context.Add(newModel);
            _context.SaveChanges();
            return newModel;
        }

        public bool Edit(Order model)
        {
            _context.Update(model);
            var update = _context.SaveChanges() > 0;
            return update;
        }

        public List<WaitingOrder> GetAllWaiting()
        {
            var resp = new List<WaitingOrder>();
            List<Order> orders = _context.Order.Where(m => m.status == 0).ToList();
            foreach (var item in orders)
            {
                var waitingOrder = new WaitingOrder();
                if (item.driverId > 0)
                {
                    Employee employee = _context.Employee.Find(item.passengerId);
                    if (employee != null)
                    {
                        waitingOrder.extension.sex = employee.sex.ToString();
                        waitingOrder.extension.isSingle = new Random().Next(0, 1) > 0.5 ? "0" : "1";
                    }
                }
                waitingOrder.info.startDateTime = item.startDateTime;
                waitingOrder.info.startPoint = item.startPoint;
                waitingOrder.info.passengerNum = item.passengerNum;
                waitingOrder.info.orderAmount = item.orderAmount;
                resp.Add(waitingOrder);
            }
            return resp;
        }
    }
}
