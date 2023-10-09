package com.financail.moneymanagement;

import android.annotation.SuppressLint;
import android.graphics.Color;
import android.graphics.Paint;
import android.os.Bundle;
import androidx.fragment.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.ListAdapter;
import android.widget.ProgressBar;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.RequestFuture;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.apptakk.http_request.HttpRequest;
import com.apptakk.http_request.HttpRequestTask;
import com.apptakk.http_request.HttpResponse;
import com.financail.moneymanagement.model.Transaction;
import com.github.mikephil.charting.charts.CandleStickChart;
import com.github.mikephil.charting.components.Description;
import com.github.mikephil.charting.components.Legend;
import com.github.mikephil.charting.components.XAxis;
import com.github.mikephil.charting.data.CandleData;
import com.github.mikephil.charting.data.CandleDataSet;
import com.github.mikephil.charting.data.CandleEntry;
import com.github.mikephil.charting.formatter.IndexAxisValueFormatter;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutionException;


public class MarketFragment extends Fragment implements AdapterView.OnItemSelectedListener{
    WebView myWebView;
    ListAdapter adapter;
    CandleStickChart candleStickChart;
    List<String> arrayList= new ArrayList<>();
    TextView inputSearch, inputBuy, inputSell;
    Spinner spinner;
    Button btnBuy, btnSell;
    ImageView icon_search;
    String tick_interval = "1d";
    String symbolCoinSearched = "BTCUSDT";
    ProgressBar progressBarSearch;

    public MarketFragment() {
        // Required empty public constructor
    }

    public static MarketFragment newInstance(String param1, String param2) {
        MarketFragment fragment = new MarketFragment();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);

        inputSearch = getActivity().findViewById(R.id.icon_search_market);

    }

    private void loadElement(View view){
        candleStickChart = view.findViewById(R.id.candleStickMarket);
        spinner = view.findViewById(R.id.sippnerTimeMarket);
        icon_search = view.findViewById(R.id.icon_search_market);
        inputSearch = view.findViewById(R.id.edt_search_market);
        inputBuy = view.findViewById(R.id.edt_buy_amount_market);
        inputSell = view.findViewById(R.id.edt_sell_amount_market);
        btnBuy = view.findViewById(R.id.btn_buy_market);
        btnSell = view.findViewById(R.id.btn_sell_market);
        progressBarSearch = view.findViewById(R.id.progressSearchMarket);
    }

    @SuppressLint("MissingInflatedId")
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view =  inflater.inflate(R.layout.fragment_market, container, false);
        String symbolCoin = "BTCUSDT";
        ArrayList<String> timeStamp = new ArrayList<>();
        ArrayList<CandleEntry> candleEntries = new ArrayList<>();

        //Load element
        loadElement(view);

        //Tìm kiếm coin và hiển thị lên đồ thị
        icon_search.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                onClickListenerBtnSearch();
            }
        });


        btnBuy.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onClickListenerBtnBuy();
            }
        });

        btnSell.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onClickListenerBtnSell();
            }
        });


        //Hiển thị đồ thị khi mở view
        RequestQueue requestQueue = Volley.newRequestQueue(getContext());
        String url = "https://api.binance.com/api/v3/klines?symbol="+symbolCoin+"&interval="+tick_interval;

        JsonArrayRequest request = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                for(int i = 0; i< response.length(); i++){
                    try {
                        JSONArray line = response.getJSONArray(i);
                        String date = "";
                        if(tick_interval.equals("1d")){
                            date = new SimpleDateFormat("dd.MM.yy").format(line.get(0));
                        }else {
                            date = new SimpleDateFormat("HH.mm").format(line.get(0));
                        }
                        timeStamp.add(date);
                        candleEntries.add(new CandleEntry(i ,Float.parseFloat((String) line.get(2)), Float.parseFloat((String) line.get(3)), Float.parseFloat((String) line.get(1)), Float.parseFloat((String) line.get(4))));

                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }

                CandleDataSet candleDataSet = new CandleDataSet(candleEntries, "Color");
                candleDataSet.setShadowColor(Color.BLUE);
                candleDataSet.setShadowWidth(1f);
                candleDataSet.setDecreasingColor(Color.RED);
                candleDataSet.setDecreasingPaintStyle(Paint.Style.FILL);

                candleDataSet.setIncreasingColor(Color.GREEN);
                candleDataSet.setIncreasingPaintStyle(Paint.Style.FILL);

                candleDataSet.setValueTextSize(0);

                CandleData candleData = new CandleData(candleDataSet);
                candleStickChart.setData(candleData);
                candleStickChart.setBackgroundColor(Color.WHITE);
                candleStickChart.setDragEnabled(true);
                candleStickChart.setTouchEnabled(true);
                candleStickChart.setVisibleXRangeMaximum(100);
                candleStickChart.moveViewToX(candleEntries.size());
                candleStickChart.setDoubleTapToZoomEnabled(true);

                Legend legend = candleStickChart.getLegend();
                legend.setTextSize(12f);

                Description description =  candleStickChart.getDescription();
                description.setTextSize(12f);

                XAxis xAxis = candleStickChart.getXAxis();
                xAxis.setValueFormatter(new IndexAxisValueFormatter(timeStamp));
                candleStickChart.getDescription().setText(symbolCoin +" in " + tick_interval);
            }

        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                error.printStackTrace();
            }
        });
        requestQueue.add(request);

        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(getContext(), R.array.Time_Array, android.R.layout.simple_spinner_item);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinner.setAdapter(adapter);
        spinner.setOnItemSelectedListener(this);
        return view;
    }

    private void onClickListenerBtnSell(){
        if(inputSell.getText().toString().isEmpty()){
            inputSell.setError("Value must than 0.");
        }else{
            FirebaseAuth mFirebaseAuth = FirebaseAuth.getInstance();
            FirebaseUser mFirebaseUser = mFirebaseAuth.getCurrentUser();
            FirebaseDatabase database = FirebaseDatabase.getInstance();
            DatabaseReference ref = database.getReference("Users").child(mFirebaseUser.getUid()).child("transaction");
            String keyFavorite = ref.push().getKey();

            Transaction transaction = new Transaction();
            String timeStamp = new SimpleDateFormat("dd.MM.yy - HH.mm").format(new java.util.Date());

            RequestQueue requestQueue = Volley.newRequestQueue(getContext());
            requestQueue.start();
            String url = "https://api.binance.com/api/v3/ticker/price?symbol="+symbolCoinSearched;

            JsonObjectRequest request1 = new JsonObjectRequest(Request.Method.GET, url, null, new Response.Listener<JSONObject>() {

                @Override
                public void onResponse(JSONObject response) {

                    try {
                        transaction.setSell(symbolCoinSearched+"/"+inputSell.getText().toString()+"/"+response.get("price")+"/"+timeStamp);
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }

                    ref.child(keyFavorite).setValue(transaction);
                    Toast.makeText(getContext(),"Sell "+inputSell.getText().toString()+" success.", Toast.LENGTH_SHORT).show();
                    inputSell.setText("");
                }
            }, new Response.ErrorListener() {
                @Override
                public void onErrorResponse(VolleyError error) {
                    error.printStackTrace();
                }
            });
            requestQueue.add(request1);
        }

    }

    private void onClickListenerBtnBuy(){
        if(inputBuy.getText().toString().isEmpty()){
            inputBuy.setError("Value must than 0.");
        }else{
            FirebaseAuth mFirebaseAuth = FirebaseAuth.getInstance();
            FirebaseUser mFirebaseUser = mFirebaseAuth.getCurrentUser();
            FirebaseDatabase database = FirebaseDatabase.getInstance();
            DatabaseReference ref = database.getReference("Users").child(mFirebaseUser.getUid()).child("transaction");
            String keyFavorite = ref.push().getKey();

            Transaction transaction = new Transaction();
            String timeStamp = new SimpleDateFormat("dd.MM.yy - HH.mm").format(new java.util.Date());

            RequestQueue requestQueue = Volley.newRequestQueue(getContext());
            requestQueue.start();
            String url = "https://api.binance.com/api/v3/ticker/price?symbol="+symbolCoinSearched;

            JsonObjectRequest request1 = new JsonObjectRequest(Request.Method.GET, url, null, new Response.Listener<JSONObject>() {

                @Override
                public void onResponse(JSONObject response) {

                    try {
                        transaction.setBuy(symbolCoinSearched+"/"+inputBuy.getText().toString()+"/"+response.get("price")+"/"+timeStamp);
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                    ref.child(keyFavorite).setValue(transaction);
                    Toast.makeText(getContext(),"Buy "+inputBuy.getText().toString()+" success.", Toast.LENGTH_SHORT).show();
                    inputBuy.setText("");
                }
            }, new Response.ErrorListener() {
                @Override
                public void onErrorResponse(VolleyError error) {
                    error.printStackTrace();
                }
            });
            requestQueue.add(request1);

        }
    }

    private void onClickListenerBtnSearch(){
        progressBarSearch.setVisibility(View.VISIBLE);
        RequestQueue requestQueue = Volley.newRequestQueue(getContext());


        String url = "https://api3.binance.com/api/v3/ticker/24hr";
        JsonArrayRequest request = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                List<String> listNameCoins = new ArrayList<>();
                for(int i = 0; i< response.length(); i++){
                    try {
                        JSONObject jsonObject = response.getJSONObject(i);
                        listNameCoins.add(jsonObject.get("symbol").toString());
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }

                }
                boolean checkFind = false;
                for (String symbolCoin: listNameCoins){
                    if(symbolCoin.equals(inputSearch.getText().toString().toUpperCase())){
                        checkFind = true;

                        //Thay đổi đồng coin
                        symbolCoinSearched = symbolCoin;
                        ArrayList<String> timeStamp = new ArrayList<>();
                        ArrayList<CandleEntry> candleEntries = new ArrayList<>();

                        RequestQueue requestQueue = Volley.newRequestQueue(getContext());
                        String url = "https://api.binance.com/api/v3/klines?symbol="+symbolCoin+"&interval="+tick_interval;


                        JsonArrayRequest request = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
                            @Override
                            public void onResponse(JSONArray response) {
                                for(int i = 0; i< response.length(); i++){
                                    try {
                                        JSONArray line = response.getJSONArray(i);
                                        String date = "";
                                        if(tick_interval.equals("1d")){
                                            date = new SimpleDateFormat("dd.MM.yy").format(line.get(0));
                                        }else {
                                            date = new SimpleDateFormat("HH.mm").format(line.get(0));
                                        }
                                        timeStamp.add(date);
                                        candleEntries.add(new CandleEntry(i ,Float.parseFloat((String) line.get(2)), Float.parseFloat((String) line.get(3)), Float.parseFloat((String) line.get(1)), Float.parseFloat((String) line.get(4))));

                                    } catch (JSONException e) {
                                        e.printStackTrace();
                                    }
                                }

                                CandleDataSet candleDataSet = new CandleDataSet(candleEntries, "Color");
                                candleDataSet.setShadowColor(Color.BLUE);
                                candleDataSet.setShadowWidth(1f);
                                candleDataSet.setDecreasingColor(Color.RED);
                                candleDataSet.setDecreasingPaintStyle(Paint.Style.FILL);

                                candleDataSet.setIncreasingColor(Color.GREEN);
                                candleDataSet.setIncreasingPaintStyle(Paint.Style.FILL);

                                candleDataSet.setValueTextSize(0);

                                CandleData candleData = new CandleData(candleDataSet);
                                candleStickChart.setData(candleData);
                                candleStickChart.setBackgroundColor(Color.WHITE);
                                candleStickChart.setDragEnabled(true);
                                candleStickChart.setTouchEnabled(true);
                                candleStickChart.setVisibleXRangeMaximum(100);
                                candleStickChart.moveViewToX(candleEntries.size());
                                candleStickChart.setDoubleTapToZoomEnabled(true);

                                Legend legend = candleStickChart.getLegend();
                                legend.setTextSize(12f);

                                Description description =  candleStickChart.getDescription();
                                description.setTextSize(12f);

                                XAxis xAxis = candleStickChart.getXAxis();
                                xAxis.setValueFormatter(new IndexAxisValueFormatter(timeStamp));
                                candleStickChart.getDescription().setText(symbolCoin +" in " + tick_interval);
                                progressBarSearch.setVisibility(View.INVISIBLE);
                                inputSearch.setText("");
                            }

                        }, new Response.ErrorListener() {
                            @Override
                            public void onErrorResponse(VolleyError error) {
                                error.printStackTrace();
                            }
                        });
                        requestQueue.add(request);
                    }
                }
                if(!checkFind){
                    Toast.makeText(getContext(),"Coin not exist.", Toast.LENGTH_SHORT).show();
                    progressBarSearch.setVisibility(View.INVISIBLE);
                }
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                error.printStackTrace();
            }
        });

        requestQueue.add(request);

    }

    // Thay đổi đồ thị theo thời gian
    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
        tick_interval = parent.getItemAtPosition(position).toString();
        String symbolCoin = symbolCoinSearched;
        ArrayList<String> timeStamp = new ArrayList<>();
        ArrayList<CandleEntry> candleEntries = new ArrayList<>();

        RequestQueue requestQueue = Volley.newRequestQueue(getContext());
        String url = "https://api.binance.com/api/v3/klines?symbol="+symbolCoin+"&interval="+tick_interval;

        JsonArrayRequest request = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                for(int i = 0; i< response.length(); i++){
                    try {
                        JSONArray line = response.getJSONArray(i);
                        String date = "";
                        if(tick_interval.equals("1d")){
                            date = new SimpleDateFormat("dd.MM.yy").format(line.get(0));
                        }else {
                            date = new SimpleDateFormat("HH.mm").format(line.get(0));
                        }
                        timeStamp.add(date);
                        candleEntries.add(new CandleEntry(i ,Float.parseFloat((String) line.get(2)), Float.parseFloat((String) line.get(3)), Float.parseFloat((String) line.get(1)), Float.parseFloat((String) line.get(4))));

                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }

                CandleDataSet candleDataSet = new CandleDataSet(candleEntries, "Color");
                candleDataSet.setShadowColor(Color.BLUE);
                candleDataSet.setShadowWidth(1f);
                candleDataSet.setDecreasingColor(Color.RED);
                candleDataSet.setDecreasingPaintStyle(Paint.Style.FILL);

                candleDataSet.setIncreasingColor(Color.GREEN);
                candleDataSet.setIncreasingPaintStyle(Paint.Style.FILL);

                candleDataSet.setValueTextSize(0);

                CandleData candleData = new CandleData(candleDataSet);
                candleStickChart.setData(candleData);
                candleStickChart.setBackgroundColor(Color.WHITE);
                candleStickChart.setDragEnabled(true);
                candleStickChart.setTouchEnabled(true);
                candleStickChart.setVisibleXRangeMaximum(100);
                candleStickChart.moveViewToX(candleEntries.size());
                candleStickChart.setDoubleTapToZoomEnabled(true);

                Legend legend = candleStickChart.getLegend();
                legend.setTextSize(12f);

                Description description =  candleStickChart.getDescription();
                description.setTextSize(12f);

                XAxis xAxis = candleStickChart.getXAxis();
                xAxis.setValueFormatter(new IndexAxisValueFormatter(timeStamp));
                candleStickChart.getDescription().setText(symbolCoin +" in " + tick_interval);
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
    public void onNothingSelected(AdapterView<?> parent) {

    }

}