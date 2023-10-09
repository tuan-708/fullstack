package com.financail.moneymanagement.login;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.util.Patterns;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.financail.moneymanagement.R;
import com.financail.moneymanagement.model.User;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.database.FirebaseDatabase;

import java.util.Objects;

public class RegistrationActivity extends AppCompatActivity {

    private TextView e_fullName_register, e_email_register, e_password_register;
    private Button e_btnRegiterAccount;
    private FirebaseAuth mAuth;
    private ProgressBar e_progressBar;

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registration);

        e_fullName_register = (EditText)findViewById(R.id.fullname_register);
        e_email_register = (EditText)findViewById(R.id.email_register);
        e_password_register = (EditText)findViewById(R.id.password_register);
        e_progressBar = (ProgressBar)findViewById(R.id.progressBar);

        e_btnRegiterAccount = findViewById(R.id.btnRegisterAccount);


        e_btnRegiterAccount.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                mAuth = FirebaseAuth.getInstance();
                FirebaseUser user = mAuth.getCurrentUser();

                String fullName = e_fullName_register.getText().toString().trim();
                String email = e_email_register.getText().toString().trim();
                String password = e_password_register.getText().toString().trim();

                if (!(validFullName(fullName) && validEmail(email) && validPasword(password))){
                    return;
                }

                e_progressBar.setVisibility(View.VISIBLE);
                mAuth.createUserWithEmailAndPassword(email, password).addOnCompleteListener(new OnCompleteListener<AuthResult>() {
                    @Override
                    public void onComplete(@NonNull Task<AuthResult> task) {
                        if(task.isSuccessful()){
                            User user = new User(fullName, email);

                            FirebaseDatabase.getInstance().getReference("Users")
                                    .child(Objects.requireNonNull(FirebaseAuth.getInstance().getUid()))
                                    .setValue(user).addOnCompleteListener(new OnCompleteListener<Void>() {
                                        @Override
                                        public void onComplete(@NonNull Task<Void> task) {
                                            if(task.isSuccessful()){
                                                Toast.makeText(RegistrationActivity.this, "User has been registed successfully.", Toast.LENGTH_LONG).show();
                                                e_progressBar.setVisibility(View.INVISIBLE);

                                                Intent intent = new Intent( RegistrationActivity.this, LoginActivity.class);
                                                startActivity(intent);
                                            }else {
                                                Toast.makeText(RegistrationActivity.this, "Faild to register. Try again!", Toast.LENGTH_LONG).show();
                                                e_progressBar.setVisibility(View.INVISIBLE);
                                            }
                                        }
                                    });
                        }else {
                            Toast.makeText(RegistrationActivity.this, "Email is registered.", Toast.LENGTH_LONG).show();
                            e_progressBar.setVisibility(View.INVISIBLE);
                        }
                    }
                });

            }
        });
    }

    private Boolean validFullName(String fullName){
        if(fullName.isEmpty()){
            e_fullName_register.setError("Full Name is required.");
            e_fullName_register.requestFocus();
            return false;
        }
        if(fullName.length() < 3){
            e_fullName_register.setError("Full Name is so short.");
            e_fullName_register.requestFocus();
            return false;
        }
        return true;
    }

    private Boolean validEmail(String email){
        if(email.isEmpty()){
            e_email_register.setError("Email is required.");
            e_email_register.requestFocus();
            return false;
        }

        if(!Patterns.EMAIL_ADDRESS.matcher(email).matches()){
            e_email_register.setError("Please provide valid email.");
            e_email_register.requestFocus();
            return false;
        }

        return true;
    }

    private Boolean validPasword(String password){
        if(password.isEmpty()){
            e_password_register.setError("Password is required.");
            e_password_register.requestFocus();
            return false;
        }
        if(password.length() < 8){
            e_password_register.setError("Password is 8-16 charater.");
            e_password_register.requestFocus();
            return false;
        }

        if(password.length() > 16){
            e_password_register.setError("Password is 8-16 charater.");
            e_password_register.requestFocus();
            return false;
        }
        return true;
    }
}