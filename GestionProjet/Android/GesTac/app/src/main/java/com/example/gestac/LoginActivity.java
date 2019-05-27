package com.example.gestac;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import constant.Constant;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import webservice.model.ResLogin;
import webservice.remote.RetrofitClient;
import webservice.remote.UserService;

public class LoginActivity extends AppCompatActivity{
    private EditText edUsername, edPassword;
    private Button btnLogin;
    public static UserService serviceApi;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.activity_main);
        setContentView(R.layout.activity_login);

        edUsername = (EditText) findViewById(R.id.edUsername);
        edPassword = (EditText) findViewById(R.id.edPassword);
        btnLogin = (Button) findViewById(R.id.login);

        serviceApi = RetrofitClient.getApi(Constant.mainUrl.MAIN_URL).create(UserService.class);

        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view){
                if (validChamps())
                    loginUser();
            }

    });

    }

    private void loginUser()  {
        String usr = edUsername.getText().toString();
        String pass = edPassword.getText().toString();

        //serviceApi.login(usr,pass, new Callback<ResLogin>(){

        try {

            Call<ResLogin> userCall = serviceApi.login(usr, pass);
            userCall.enqueue(new Callback<ResLogin>() {
                @Override
                public void onResponse(Call<ResLogin> call, Response<ResLogin> response) {
                    //Log.e("onResponse", response.body().getMessage());
                    //Toast.makeText(LoginActivity.this, response.body().getMessage(), Toast.LENGTH_LONG).show();
                    //if (response.body().getConnexion().equals("1")){
                    if (response.isSuccessful()) {
                        if (response.body().getConnexion() == 1) {
                            Toast.makeText(LoginActivity.this, "Bienvenue",Toast.LENGTH_LONG).show();
                            //Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                            Intent intent = new Intent(LoginActivity.this, TaskListActivity.class);
                            intent.putExtra("user", edUsername.getText().toString());
                            startActivity(intent);
                        } else {
                            edUsername.setText("");
                            edPassword.setText("");
                            Toast.makeText(LoginActivity.this, "Utilisateur ou mot de passe invalide",Toast.LENGTH_LONG).show();
                        }
                    }
                }
               @Override
                public void onFailure(Call<ResLogin> call, Throwable t) {
                   Log.e("ERROR: ", t.getMessage());
                }
            });

        } catch (Exception e) {
            Log.e("Erreur",e.getMessage().toString());
            Toast.makeText(LoginActivity.this, e.getMessage().toString(), Toast.LENGTH_LONG).show();
        }

    }

    private boolean validChamps(){
        boolean result = true;
        String message="";
        if (TextUtils.isEmpty(edUsername.getText().toString()))
            message = "Veuillez rentrer un utilisateur";

        if (TextUtils.isEmpty(edPassword.getText().toString()))
            message = "Veuillez rentrer un mot de passe";

        if (message!=""){
            result = false;
            Toast.makeText(LoginActivity.this, message, Toast.LENGTH_LONG).show();
        }

        return result;
    }



}
