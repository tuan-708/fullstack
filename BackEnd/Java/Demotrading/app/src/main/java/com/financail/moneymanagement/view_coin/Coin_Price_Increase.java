package com.financail.moneymanagement.view_coin;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ProgressBar;

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
import com.financail.moneymanagement.R;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Coin_Price_Increase extends Fragment {
    private ProgressBar e_progressBar;

    public Coin_Price_Increase() {
        // Required empty public constructor
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
        View view =  inflater.inflate(R.layout.fragment_top_coin, container, false);
        e_progressBar = (ProgressBar)view.findViewById(R.id.progressBarCoinTop);

        final FragmentActivity c = getActivity();
        final RecyclerView recyclerView = (RecyclerView) view.findViewById(R.id.recyclerViewCoinTop);
        LinearLayoutManager layoutManager = new LinearLayoutManager(c);
        recyclerView.setLayoutManager(layoutManager);

        RequestQueue requestQueue = Volley.newRequestQueue(getActivity());
        e_progressBar.setVisibility(View.VISIBLE);
        List<Coin> coinList = new ArrayList<>();

        String url = "https://api3.binance.com/api/v3/ticker/24hr";
        JsonArrayRequest request = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                for(int i = 0; i< response.length(); i++){
                    try {
                        JSONObject jsonObject = response.getJSONObject(i);
                        if(jsonObject.get("symbol").toString().endsWith("USDT")){
                            String symbol = (String) jsonObject.get("symbol");
                            Float price =  Float.parseFloat(String.valueOf(jsonObject.get("lastPrice")));
                            DecimalFormat df = new DecimalFormat("0.000");
                            String price_d = df.format(price);
                            String price_v = df.format(price*25000);
                            String price_24 = jsonObject.get("priceChangePercent").toString();
                            Coin coin = new Coin(symbol, price_d, price_v+"đ",price_24 );
                            coinList.add(coin);
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

        return view;
    }

}