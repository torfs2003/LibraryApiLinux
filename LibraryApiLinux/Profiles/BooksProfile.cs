using AutoMapper;
using LibraryApiLinux.Models;
using LibraryApiLinux.dtos;
using System;

namespace LibraryApiLinux.Profiles
{
    class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookReadDto>();
            CreateMap<BookWriteDto, Book>();
            CreateMap<BookUpdateDto, Book>();
        }
    }
}
