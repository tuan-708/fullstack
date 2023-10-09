package com.financail.moneymanagement.view_coin;

import android.annotation.SuppressLint;
import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ProgressBar;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;
import com.financail.moneymanagement.MainActivity;
import com.financail.moneymanagement.R;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class Coin_Favourite extends Fragment {
    private FirebaseAuth mFirebaseAuth;
    private ProgressBar e_progressBar;

    public Coin_Favourite() {
        // Required empty public constructor
    }

    public static Coin_Favourite newInstance() {
        Coin_Favourite fragment = new Coin_Favourite();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @SuppressLint("MissingInflatedId")
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view =  inflater.inflate(R.layout.fragment_favourite_coin, container, false);
        e_progressBar = (ProgressBar)view.findViewById(R.id.progressBarCoinFavorite);

        final FragmentActivity c = getActivity();
        final RecyclerView recyclerView = (RecyclerView) view.findViewById(R.id.recyclerViewCoinFavorite);
        LinearLayoutManager layoutManager = new LinearLayoutManager(c);
        recyclerView.setLayoutManager(layoutManager);

        RequestQueue requestQueue = Volley.newRequestQueue(getActivity());
        e_progressBar.setVisibility(View.VISIBLE);

        List<String> coinFavoriteList = new MainActivity().getCoinFavourite();
        mFirebaseAuth = FirebaseAuth.getInstance();
        FirebaseUser mFirebaseUser = mFirebaseAuth.getCurrentUser();
        FirebaseDatabase database = FirebaseDatabase.getInstance();
        DatabaseReference ref = database.getReference("Users").child(mFirebaseUser.getUid()).child("favourite");
        ref.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(DataSnapshot snapshot) {
                for (DataSnapshot child: snapshot.getChildren()){
                    String key = child.getKey();
                    for (DataSnapshot child1: child.getChildren()){
                        String favourite = child1.getValue(String.class);
                        coinFavoriteList.add(favourite);
                    }
                }

                Set<String> set = new HashSet<String>(coinFavoriteList);
                List<String> coinFavoriteList = new ArrayList<String>(set);
                List<Coin> coinList = new ArrayList<>();

                String url = "https://api3.binance.com/api/v3/ticker/24hr";
                JsonArrayRequest request = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
                    @Override
                    public void onResponse(JSONArray response) {
                        for(int i = 0; i< response.length(); i++){
                            try {
                                JSONObject jsonObject = response.getJSONObject(i);

                                for (String item : coinFavoriteList){
                                    if(jsonObject.get("symbol").toString().equals(item)){
                                        String symbol = (String) jsonObject.get("symbol");
                                        Float price =  Float.parseFloat(String.valueOf(jsonObject.get("lastPrice")));
                                        DecimalFormat df = new DecimalFormat("0.000");
                                        String price_d = df.format(price);
                                        String price_v = df.format(price*25000);
                                        String price_24 = jsonObject.get("priceChangePercent").toString();
                                        Coin coin = new Coin(symbol, price_d, price_v+"đ",price_24 );
                                        coinList.add(coin);
                                    }
                                }
                            } catch (JSONException e) {
                                e.printStackTrace();
                            }
                        }

                        Collections.sort(coinList, new SortByPriceIncrease());

                        final CoinAdapter adapter = new CoinAdapter(c, coinList);
                        recyclerView.setAdapter(adapter);
                        e_progressBar.setVisibility(View.INVISIBLE);

                    }
                }, new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        error.printStackTrace();
                    }
                });

                requestQueue.add(request);


            }
            @Override
            public void onCancelled(@NonNull DatabaseError error) {
            }
        });



        return view;
    }
}