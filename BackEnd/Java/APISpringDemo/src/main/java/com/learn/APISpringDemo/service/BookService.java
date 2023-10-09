package com.learn.APISpringDemo.service;
import com.learn.APISpringDemo.model.Author;
import com.learn.APISpringDemo.model.Book;
import com.learn.APISpringDemo.repository.AuthorRepository;
import com.learn.APISpringDemo.repository.BookRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Collections;
import java.util.List;
import java.util.Optional;

@Service
public class BookService {

    @Autowired
    private BookRepository bookRepository;

    @Autowired
    private AuthorRepository authorRepository;

    public List<Book> getAllbook(){
        List<Book> books = this.bookRepository.findAll();

        return books;
    }

    public Optional<Book> getBookById(Integer id){

        Optional<Book> book = Optional.ofNullable(this.bookRepository.findById(id).orElseThrow(() -> new RuntimeException("Can't find book with id " + id)));

        return book;
    }

    public Book createBook(Book book){
        return this.bookRepository.save(book);
    }


    public Book updateBook(Book book, int id){

        Optional<Book> b = Optional.ofNullable(this.bookRepository.findById(id).orElseThrow(() -> new RuntimeException("Can't find book with id " + id)));
        if(b.isPresent()){
            Book bookUpdate = b.get();

            bookUpdate.setBookName(book.getBookName());
            bookUpdate.setBookTitle(book.getBookTitle());


            Optional<Author> au = Optional.ofNullable(this.authorRepository.findById(book.getAuthor().getId()).orElseThrow(() -> new RuntimeException("Can't found author with id " + book.getAuthor().getId())));
            if(au.isPresent()){
                bookUpdate.setAuthor(book.getAuthor());
                Book updated =  this.bookRepository.save(bookUpdate);

                return updated;
            }
        }
        return null;
    }

    public Book deleteBookById(int id){
        Optional<Book> bo = Optional.ofNullable(this.bookRepository.findById(id).orElseThrow(() -> new RuntimeException("Can't found book id.")));
        if(bo.isPresent()){
            this.bookRepository.deleteById(id);
            return bo.get();
        }
      return  null;
    }
}
