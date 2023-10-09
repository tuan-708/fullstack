package com.learn.APISpringDemo.service;

import org.apache.commons.io.FilenameUtils;
import org.springframework.core.io.Resource;
import org.springframework.core.io.UrlResource;
import org.springframework.stereotype.Service;
import org.springframework.util.StreamUtils;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;
import java.io.InputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.Arrays;
import java.util.UUID;
import java.util.stream.Stream;

@Service
public class ImageStorageService  implements IStoreService{

    private final Path storageFolder = Paths.get("uploads");

    public ImageStorageService(){
        try{
            Files.createDirectories(storageFolder);
        }catch (Exception exception){
            throw new RuntimeException("Cannot initialize storage", exception);
        }
    }

    private boolean isImageFile(MultipartFile file){
        String fileExtension = FilenameUtils.getExtension(file.getOriginalFilename());
        return Arrays.asList(
                new String[]{"png","jpg","jpeg","bmp"}
        ).contains(fileExtension.trim().toLowerCase());
    }

    @Override
    public String storeFile(MultipartFile file) {
        try {
            if(file.isEmpty()){
                throw new RuntimeException(("Faild to store empty fild."));
            }

            if(!isImageFile(file)){
                throw new RuntimeException("You can only upload image file");
            }

            float fileSizeInMegabytes = file.getSize()/ 1_000_000.0f;

            if(fileSizeInMegabytes > 5.0f){
                throw new RuntimeException("File must be <= 5Mb");
            }

            //File must be rename, why?
            String fileExtension = FilenameUtils.getExtension(file.getOriginalFilename());
            String generatedfileName = UUID.randomUUID().toString().replace("-","");
            generatedfileName = generatedfileName + "."+fileExtension;

            Path detinationFilePath = this.storageFolder.resolve(
                    Paths.get(generatedfileName)
            ).normalize().toAbsolutePath();

            if(!detinationFilePath.getParent().equals(this.storageFolder.toAbsolutePath())){
                throw new RuntimeException("Cannot store file outside current directory.");
            }

            try (InputStream inputStream = file.getInputStream()){
                Files.copy(inputStream, detinationFilePath, StandardCopyOption.REPLACE_EXISTING);
            }

            return generatedfileName;

        }catch (Exception exception){
            throw new RuntimeException(("Faild to store file."), exception);
        }
    }

    @Override
    public Stream<Path> loadAll() {
        try{
            return Files.walk(this.storageFolder,1)
                    .filter(path -> !path.equals(this.storageFolder))
                    .map(this.storageFolder::relativize);
        }catch (Exception e){
            throw new RuntimeException("Faild to load stored files", e);
        }
    }

    @Override
    public byte[] readFileContent(String fileName) {
        try{
            Path file  = storageFolder.resolve(fileName);
            Resource resource = new UrlResource(file.toUri());

            if(resource.exists() || resource.isReadable()){
                byte[] bytes = StreamUtils.copyToByteArray(resource.getInputStream());
                return bytes;
            }else{
                throw  new RuntimeException("Could not read file"+fileName);

            }
        } catch (Exception ex) {
            throw new RuntimeException("Could not read file:"+ fileName, ex);
        }
    }

    @Override
    public void deleteFiles(String fileName) throws IOException {
        Path detinationFilePath = this.storageFolder.resolve(
                Paths.get(fileName)
        ).normalize().toAbsolutePath();

        Files.delete(detinationFilePath);
    }
}
