package com.financail.moneymanagement;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;
import androidx.viewpager.widget.ViewPager;


import com.financail.moneymanagement.model.Coin;

import java.text.DecimalFormat;
import java.util.List;


public class TransactionAdapter extends RecyclerView.Adapter<TransactionAdapter.ViewHolder> {
    private List<Coin> coinList;
    private Activity context;
    private ViewPager mViewPager;
    private WebView webView;

    @SuppressLint("NotifyDataSetChanged")
    public TransactionAdapter(Activity contextN, List<Coin> coinList){
        this.context = contextN;
        this.coinList = coinList;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.list_row_coin_hold, parent, false);
        return new ViewHolder(view);
    }

    public String[] mColors = {"#2ebd84", "#f5465c"};

    @SuppressLint({"ResourceAsColor", "SetTextI18n"})
    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        Coin coin = coinList.get(position);

        holder.name.setText(coin.getName());
        holder.quantity.setText(String.valueOf(coin.getQuantity()));
        holder.date.setText(coin.getDate());
        holder.price.setText(String.valueOf(coin.getPrice()));
        holder.percent.setText(String.valueOf(coin.getPercent()));

        float percent_price = coin.getPercent();
        DecimalFormat fromat = new DecimalFormat("##0.0000");
        if(percent_price > 0){
            holder.percent.setText("+"+fromat.format(percent_price)+"%");
            holder.percent.setBackgroundColor(Color.parseColor(mColors[0]));
        }else {
            holder.percent.setText(fromat.format(percent_price)+"%");
            holder.percent.setBackgroundColor(Color.parseColor(mColors[1]));
        }

    }

    @Override
    public int getItemCount() {
        return coinList.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder{
        private TextView name, quantity, date, price, percent;
        @SuppressLint("CutPasteId")
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            name = itemView.findViewById(R.id.item_coin_name_mm);
            price = itemView.findViewById(R.id.item_coin_price_mm);
            quantity = itemView.findViewById(R.id.item_coin_amount_mm);
            date = itemView.findViewById(R.id.item_coin_date_mm);
            percent = itemView.findViewById(R.id.item_coin_percent_mm);

            itemView.setOnClickListener(new View.OnClickListener() {
                @SuppressLint("ResourceType")
                @Override
                public void onClick(View v) {

                    Intent itent = new Intent(context, CoinViewDetail.class);
                    itent.putExtra("symbol", name.getText().toString());
                    context.startActivity(itent);
                }
            });
        }
    }
}
