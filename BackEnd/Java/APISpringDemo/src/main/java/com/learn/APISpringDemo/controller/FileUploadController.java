package com.learn.APISpringDemo.controller;

import com.learn.APISpringDemo.model.ResponeObject;
import com.learn.APISpringDemo.service.IStoreService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.mvc.method.annotation.MvcUriComponentsBuilder;

import java.util.List;
import java.util.stream.Collectors;

@RestController
public class FileUploadController {
    //This controller recevice file/image from client

    @Autowired
    private IStoreService storeService;

    @PostMapping(path = "/upload-file")
    public ResponseEntity<ResponeObject> uploadFile(@RequestParam("file") MultipartFile file){
        try{

            String generatedFileName = storeService.storeFile(file);
            return ResponseEntity.status(HttpStatus.OK).body(
                    new ResponeObject("ok","upload file successfully", 1,generatedFileName)
            );
        }catch (Exception ex){
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(
                    new ResponeObject("false","upload file failed", 0, "")
            );
        }
    }

    @GetMapping(path = "/files/{fileName:.+}")
    public ResponseEntity<byte[]> readDetailFile(@PathVariable String fileName){
        try{
            byte[] bytes = storeService.readFileContent(fileName);
            return ResponseEntity.ok().contentType(MediaType.IMAGE_JPEG).body(bytes);
        }catch (Exception exception){
            return ResponseEntity.noContent().build();
        }
    }

    @GetMapping(path = "/files")
    public ResponseEntity<ResponeObject> getUploaedFiles(){
        try{
            List<String> urls = storeService.loadAll()
                    .map(path -> {
                        String urlPath = MvcUriComponentsBuilder.fromMethodName(
                                FileUploadController.class, "readDetailFile", path.getFileName().toString()).build().toUri().toString();
                        return urlPath;
                    }).collect(Collectors.toList());

            return ResponseEntity.status(HttpStatus.OK).body(
                    new ResponeObject("ok", "Query successfully", urls.size(), urls)
            );
        }catch (Exception ex){
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(
                    new ResponeObject("false","read files failed", 0, "")
            );
        }
    }

    @PutMapping(path = "/files/{fileName:.+}")
    public ResponseEntity<ResponeObject> deleteFileByName(@PathVariable String fileName){
        try{
            this.storeService.deleteFiles(fileName);
            return ResponseEntity.status(HttpStatus.OK).body(
                    new ResponeObject("ok","Delete File successfully", 1, fileName)
            );
        }catch (Exception e){
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(
                    new ResponeObject("false","Detete file "+fileName+ "failded", 0, "")
            );
        }
    }
}
