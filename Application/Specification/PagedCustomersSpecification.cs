﻿using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specification
{
    public class PagedCustomersSpecification : Specification<Customer>
    {
        public PagedCustomersSpecification(int pageSize, int pageNumber, string nombre, string apellido)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(nombre))
                Query.Search(x => x.Nombre, "%" + nombre + "%");

            if (!string.IsNullOrEmpty(apellido))
                Query.Search(x => x.Nombre, "%" + nombre + "%");

        }
    }
}
