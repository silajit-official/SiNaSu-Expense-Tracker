﻿using ExpTracker.Models;

namespace ExpTracker.Repository
{
    public interface IExpTrackerRepository
    {
        string AddNewCustomer(Customer customer);
        string Login(Customer customer);
    }
}