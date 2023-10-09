package com.financail.moneymanagement;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.view.WindowManager;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.ImageView;

import com.financail.moneymanagement.login.LoginActivity;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;

public class PlashScreenActivity extends AppCompatActivity {
    private FirebaseAuth mFirebaseAuth;
    private static int SPLASH = 3000;
    Animation animation;
    private ImageView imageView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        setContentView(R.layout.activity_plash_screen);

        animation = AnimationUtils.loadAnimation(this,R.anim.animation_login);


        imageView = findViewById(R.id.image_Logo);

        imageView.setAnimation(animation);

        new Handler().postDelayed(new Runnable() {

            @Override
            public void run() {

                mFirebaseAuth = FirebaseAuth.getInstance();
                FirebaseUser mFirebaseUser = mFirebaseAuth.getCurrentUser();
//                FirebaseAuth.getInstance().signOut();
                if(mFirebaseUser != null){

                }else {
                    startActivity(new Intent(PlashScreenActivity.this, LoginActivity.class));
                    finish();
                    return;
                }

                Intent intent = new Intent( PlashScreenActivity.this, MainActivity.class);
                startActivity(intent);
                finish();
            }
        }, SPLASH);
    }
}