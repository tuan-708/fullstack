package com.financail.moneymanagement;

import android.graphics.Color;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ProgressBar;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;
import com.financail.moneymanagement.model.Coin;
import com.financail.moneymanagement.view_coin.CoinAdapter;
import com.github.mikephil.charting.charts.PieChart;
import com.github.mikephil.charting.components.Legend;
import com.github.mikephil.charting.data.PieData;
import com.github.mikephil.charting.data.PieDataSet;
import com.github.mikephil.charting.data.PieEntry;
import com.github.mikephil.charting.formatter.PercentFormatter;
import com.github.mikephil.charting.formatter.ValueFormatter;
import com.github.mikephil.charting.utils.ColorTemplate;
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
import java.util.List;


public class MoneyFragment extends Fragment {
    private PieChart pieChart;
    private FirebaseAuth mFirebaseAuth;
    private ProgressBar progressBar;
    private RecyclerView recyclerView;
    List<Coin> totalListCoin;

    public MoneyFragment() {
        // Required empty public constructor
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view =  inflater.inflate(R.layout.fragment_money, container, false);
        progressBar = view.findViewById(R.id.progressBarMoneyManagement);
        pieChart = view.findViewById(R.id.piechartMM);

        setupPechart();
        drawPiechart();

        final FragmentActivity c = getActivity();
        final RecyclerView recyclerView = view.findViewById(R.id.recyclerViewMM);;
        LinearLayoutManager layoutManager = new LinearLayoutManager(c);
        recyclerView.setLayoutManager(layoutManager);

        mFirebaseAuth = FirebaseAuth.getInstance();
        FirebaseUser mFirebaseUser = mFirebaseAuth.getCurrentUser();
        FirebaseDatabase database = FirebaseDatabase.getInstance();
        DatabaseReference ref = database.getReference("Users").child(mFirebaseUser.getUid()).child("transaction");



        ref.addValueEventListener(new ValueEventListener(){

            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                try {
                    List<Coin> Transactions = new ArrayList<>();
                    for (DataSnapshot child: snapshot.getChildren()){
                        String key = child.getKey();
                        for (DataSnapshot child1: child.getChildren()){
                            String transaction = child1.getValue(String.class);
                            String[] words = transaction.split("/");
                            Coin coin = new Coin();
                            coin.setName(words[0]);
                            coin.setQuantity(Float.parseFloat(words[1]));
                            coin.setPrice(Float.parseFloat(words[2]));
                            coin.setDate(words[3]);
                            Transactions.add(coin);
                        }
                    }

                    RequestQueue requestQueue = Volley.newRequestQueue(getActivity());
                    List<Coin> coinList = new ArrayList<>();

                    String url = "https://api.binance.com/api/v3/ticker/price";
                    JsonArrayRequest request = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
                        @Override
                        public void onResponse(JSONArray response) {
                            int index = 0;
                            for (Coin transaction: Transactions){
                                for(int i = 0; i< response.length(); i++){
                                    try {
                                        JSONObject jsonObject = response.getJSONObject(i);
                                        if(jsonObject.get("symbol").toString().equals(transaction.getName())){
                                            Float price =  Float.parseFloat(String.valueOf(jsonObject.get("price")));
                                            float percent = (( price/ transaction.getPrice()) - 1)*100;
                                            transaction.setPercent(percent);
                                            Coin newC = transaction;
                                            Transactions.set(index, newC);
                                        }
                                    } catch (JSONException e) {
                                        e.printStackTrace();
                                    }
                                }
                                index += 1;
                            }

                            TransactionAdapter adapter = new TransactionAdapter(c, Transactions);
                            recyclerView.setAdapter(adapter);

                        }
                    }, new Response.ErrorListener() {
                        @Override
                        public void onErrorResponse(VolleyError error) {
                            error.printStackTrace();
                        }
                    });
                    requestQueue.add(request);
                }catch (Exception ex){
                    ex.printStackTrace();
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });

        return view;
    }

    private void setupPechart(){
        progressBar.setVisibility(View.VISIBLE);
        pieChart.setDrawHoleEnabled(true);
        pieChart.setEntryLabelTextSize(12);
        pieChart.setEntryLabelColor(Color.BLACK);
        pieChart.setCenterText("Total Asset");
        pieChart.setCenterTextSize(22);
        pieChart.getDescription().setEnabled(false);

        Legend l = pieChart.getLegend();
        l.setVerticalAlignment(Legend.LegendVerticalAlignment.BOTTOM);
        l.setOrientation(Legend.LegendOrientation.HORIZONTAL);
        l.setTextSize(12);
        l.setDrawInside(false);
        l.setEnabled(true);
    }

    public class MyValueFormatter extends ValueFormatter {
        private final DecimalFormat mFormat;

        public MyValueFormatter() {
            mFormat = new DecimalFormat("###,###,##0.0"); // use one decimal
        }

        @Override
        public String getFormattedValue(float value) {
            return mFormat.format(value) + " %"; // e.g. append percentage sign
        }
    }


    private void drawPiechart(){

        mFirebaseAuth = FirebaseAuth.getInstance();
        FirebaseUser mFirebaseUser = mFirebaseAuth.getCurrentUser();
        FirebaseDatabase database = FirebaseDatabase.getInstance();
        DatabaseReference ref = database.getReference("Users").child(mFirebaseUser.getUid()).child("transaction");


        ref.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(DataSnapshot snapshot) {
                try {
                    List<Coin> coinListHold = new ArrayList<>();
                    for (DataSnapshot child: snapshot.getChildren()){
                        String key = child.getKey();
                        for (DataSnapshot child1: child.getChildren()){
                            String transaction = child1.getValue(String.class);
                            String[] words = transaction.split("/");

                            if(child1.getKey().equals("buy")){
                                Coin coin = new Coin();
                                coin.setName(words[0]);
                                coin.setQuantity(Float.parseFloat(words[1]));
                                coin.setPrice(Float.parseFloat(words[2]));
                                coin.setDate(words[3]);
                                coinListHold.add(coin);
                            }else {
                                Coin coin = new Coin();
                                coin.setName(words[0]);
                                coin.setQuantity(-Float.parseFloat(words[1]));
                                coin.setPrice(Float.parseFloat(words[2]));
                                coin.setDate(words[3]);
                                coinListHold.add(coin);
                            }
                        }
                    }
                    ArrayList<PieEntry> entries = new ArrayList<>();

                    totalListCoin = getListTotalCoinHold(coinListHold);
                    List<String> coinName = coinNameHold(coinListHold);

                    RequestQueue requestQueue = Volley.newRequestQueue(getContext());
                    String url = "https://api.binance.com/api/v3/ticker/price";

                    JsonArrayRequest request = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
                        @Override
                        public void onResponse(JSONArray response) {
                            for (String name : coinName) {
                                for (int i = 0; i < response.length(); i++) {
                                    try {
                                        JSONObject jsonObject = response.getJSONObject(i);
                                        if (jsonObject.get("symbol").toString().equals(name)) {
                                            Float price = Float.parseFloat(String.valueOf(jsonObject.get("price")));

                                            for (Coin coin : totalListCoin) {
                                                if (coin.getName().equals(name)) {
                                                    coin.setPrice(price);
                                                }
                                            }
                                        }
                                    } catch (JSONException e) {
                                        e.printStackTrace();
                                    }
                                }
                            }

                            for (Coin coin : totalListCoin) {
                                entries.add(new PieEntry(coin.getQuantity() * coin.getPrice(), coin.getName().substring(0, coin.getName().length() - 4)));
                            }

                            ArrayList<Integer> colors = new ArrayList<>();

                            for (int color : ColorTemplate.MATERIAL_COLORS) {
                                colors.add(color);
                            }

                            for (int color : ColorTemplate.VORDIPLOM_COLORS) {
                                colors.add(color);
                            }

                            PieDataSet dataSet = new PieDataSet(entries, "Coin Name");
                            dataSet.setColors(colors);

                            PieData data = new PieData(dataSet);
                            data.setDrawValues(true);
//                        data.setValueFormatter(new PercentFormatter(pieChart));
                            data.setValueTextSize(12f);
                            data.setValueTextColor(Color.BLACK);
                            data.setValueFormatter(new PercentFormatter(pieChart));

                            pieChart.setData(data);
                            pieChart.invalidate();
                            progressBar.setVisibility(View.INVISIBLE);
                        }
                    }, new Response.ErrorListener() {
                        @Override
                        public void onErrorResponse(VolleyError error) {
                            error.printStackTrace();
                        }
                    });
                    requestQueue.add(request);
                }catch (Exception ex){
                    ex.printStackTrace();
                }
            }
            @Override
            public void onCancelled(@NonNull DatabaseError error) {
            }
        });


    }


    private List<Coin> getListTotalCoinHold(List<Coin> coinListHold){
        ArrayList<String> coinNames = (ArrayList<String>) coinNameHold(coinListHold);
        ArrayList<Coin> newCoinList = new ArrayList<>();

        for (String name: coinNames){
            float total = 0;
            String nameC = "";
            for(Coin coin: coinListHold){
                nameC = name;
                if(coin.getName().equals(name)){
                    total += coin.getQuantity();
                }
            }
            Coin newCoin = new Coin();
            newCoin.setName(nameC);
            newCoin.setQuantity(total);
            newCoinList.add(newCoin);
        }
        return newCoinList;
    }

    private List<String> coinNameHold(List<Coin> coinListHold){
        ArrayList<String> coinNames = new ArrayList<>();
        for (Coin coin: coinListHold){
            if(!coinNames.contains(coin.getName())){
                coinNames.add(coin.getName());
            }
        }
        return coinNames;
    }
}