package com.financail.moneymanagement.login;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import android.annotation.SuppressLint;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;
import com.financail.moneymanagement.R;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.FirebaseAuth;

public class ForgotPasswordActivity extends AppCompatActivity {

    private TextView e_emailReset;
    private Button e_btnResetPassword;
    private FirebaseAuth mAuth;
    private ProgressBar e_progressBarResetPass;

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_forgot_password);

        e_emailReset = findViewById(R.id.email_reset);
        e_progressBarResetPass = findViewById(R.id.progressBarResetPass);
        e_btnResetPassword = findViewById(R.id.btnResetPassword);


        e_btnResetPassword.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                e_progressBarResetPass.setVisibility(View.VISIBLE);

                String email = e_emailReset.getText().toString().trim();
                mAuth = FirebaseAuth.getInstance();

                mAuth.sendPasswordResetEmail(email).addOnCompleteListener(new OnCompleteListener<Void>() {
                    @Override
                    public void onComplete(@NonNull Task<Void> task) {
                        if(task.isSuccessful()){
                            Toast.makeText(ForgotPasswordActivity.this,"We have sent you instructions to reset your password!",Toast.LENGTH_LONG).show();
                            e_progressBarResetPass.setVisibility(View.INVISIBLE);
                        }else {
                            Toast.makeText(ForgotPasswordActivity.this,"Failed to send reset email!", Toast.LENGTH_LONG).show();
                            e_progressBarResetPass.setVisibility(View.INVISIBLE);
                        }
                    }
                });
            }
        });

    }
}