package com.financail.moneymanagement;

import static com.financail.moneymanagement.R.id.piechartMM;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.graphics.Color;
import android.graphics.Paint;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.Spinner;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;
import com.financail.moneymanagement.model.Favourite;
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
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import org.json.JSONArray;
import org.json.JSONException;

import java.text.SimpleDateFormat;
import java.util.ArrayList;

public class CoinViewDetail extends AppCompatActivity implements AdapterView.OnItemSelectedListener {
    CandleStickChart candleStickChart;
    private Spinner spinner;
    private String symbol;
    private String tick_interval = "4h";
    private FirebaseAuth mFirebaseAuth;
    private ImageView icon_Heart;
    private String colorHeat = "";

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_coin_view_detail);
        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            symbol = extras.getString("symbol");
        }

        icon_Heart =findViewById(R.id.icon_favourite_heart);
        candleStickChart = findViewById(piechartMM);
        spinner = findViewById(R.id.sippnerTime);


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
                        if(favourite.equals(symbol)){
                            colorHeat = "Red";
                            icon_Heart.setColorFilter(Color.RED);
                        }
                    }
                }
            }
            @Override
            public void onCancelled(@NonNull DatabaseError error) {
            }
        });


        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(this, R.array.Time_Array, android.R.layout.simple_spinner_item);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinner.setAdapter(adapter);
        spinner.setOnItemSelectedListener(this);


        drawChart(symbol, tick_interval);
    }

    private void drawChart(String symbol, String tick_interval){

        String symbolCoin = symbol;
        ArrayList<String> timeStamp = new ArrayList<>();
        ArrayList<CandleEntry> candleEntries = new ArrayList<>();


        RequestQueue requestQueue = Volley.newRequestQueue(CoinViewDetail.this);
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
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
        String tick_interval = parent.getItemAtPosition(position).toString();
        candleStickChart.clear();
        drawChart(symbol, tick_interval);
    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

    }

    public void clickIconHeart(View view) {
        mFirebaseAuth = FirebaseAuth.getInstance();
        FirebaseUser mFirebaseUser = mFirebaseAuth.getCurrentUser();
        FirebaseDatabase database = FirebaseDatabase.getInstance();
        DatabaseReference ref = database.getReference("Users").child(mFirebaseUser.getUid()).child("favourite");

        if(!colorHeat.equals("Red")){
            String keyFavorite = ref.push().getKey();
            Favourite favourite = new Favourite(symbol);
            ref.child(keyFavorite).setValue(favourite);
            colorHeat = "Red";
        }
    }

    private void addFavourite(){
        mFirebaseAuth = FirebaseAuth.getInstance();
        FirebaseUser mFirebaseUser = mFirebaseAuth.getCurrentUser();
        FirebaseDatabase database = FirebaseDatabase.getInstance();
        DatabaseReference ref = database.getReference("Users").child(mFirebaseUser.getUid()).child("favourite");

        String keyFavorite = ref.push().getKey();
        Favourite favourite = new Favourite(symbol);
        ref.child(keyFavorite).setValue(favourite);
        colorHeat = "Red";
    }
}