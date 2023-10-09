package com.learn.APISpringDemo.service;

import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;
import java.nio.file.Path;
import java.util.stream.Stream;

@Service
public interface IStoreService {

    public String storeFile(MultipartFile file);

    public Stream<Path> loadAll(); //load all file inside a folder

    public byte[] readFileContent(String fileName);

    public void deleteFiles(String fileName) throws IOException;

}
