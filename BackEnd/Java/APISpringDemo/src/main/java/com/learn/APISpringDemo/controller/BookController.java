package com.learn.APISpringDemo.controller;

import com.learn.APISpringDemo.model.Book;
import com.learn.APISpringDemo.model.ResponeObject;
import com.learn.APISpringDemo.service.BookService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
public class BookController {

    @Autowired
    private BookService bookService;


    @GetMapping(path = "/api/v1/books")
    public ResponseEntity<ResponeObject> getAllBook(){

        List<Book> books = this.bookService.getAllbook();

        if(!books.isEmpty()){
            return ResponseEntity.status(HttpStatus.OK).body(
                    new ResponeObject("ok", "Query successfully", books.size(),books)
            );
        }

        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(
                new ResponeObject("false", "Don't have books", 0,"")
        );
    }

    @GetMapping(path = "/api/v1/books/{bookId}")
    public ResponseEntity<ResponeObject> getBookById(@PathVariable("bookId") int id){

        try{
            Optional<Book> book = this.bookService.getBookById(id);
            return ResponseEntity.status(HttpStatus.OK).body(
                    new ResponeObject("ok", "Query successfully", 1,book)
            );
        }catch (Exception ex){
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(
                    new ResponeObject("false",ex.getMessage(), 0,"")
            );
        }
    }

    @PostMapping(path = "/api/v1/books")
    public ResponseEntity<ResponeObject> createBook(@RequestBody Book book){
        try{
            Book b = this.bookService.createBook(book);

            return ResponseEntity.status(HttpStatus.OK).body(
                    new ResponeObject("ok", "Query succesfully", 1, b)
            );
        }catch (Exception ex){
            return ResponseEntity.status(HttpStatus.NOT_ACCEPTABLE).body(
                    new ResponeObject("false", ex.getMessage(), 0, "")
            );
        }
    }

    @PutMapping(path = "/api/v1/books/{bookId}")
    public ResponseEntity<ResponeObject> updateBook(@RequestBody Book book, @PathVariable("bookId") int id) {
        try{
            Book b = this.bookService.updateBook(book,id);

            return ResponseEntity.status(HttpStatus.OK).body(
                    new ResponeObject("ok", "Query succesfully", 1, b)
            );
        }catch (Exception ex){
            return ResponseEntity.status(HttpStatus.NOT_ACCEPTABLE).body(

                    new ResponeObject("false", ex.getMessage(), 0, "")
            );
        }
    }

    @DeleteMapping(path = "/api/v1/books/{bookId}")
    public ResponseEntity<ResponeObject> deleteBookById(@PathVariable("bookId") int id){
        try{
            Book b = this.bookService.deleteBookById(id);
            return ResponseEntity.status(HttpStatus.OK).body(
                    new ResponeObject("ok", "Query successfully",1,b)
            );
        }catch (Exception ex){
            return ResponseEntity.status(HttpStatus.NOT_ACCEPTABLE).body(

                    new ResponeObject("false", ex.getMessage(), 0, "")
            );
        }
    }
}
