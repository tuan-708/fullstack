package com.financail.moneymanagement.view_coin;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;
import androidx.viewpager.widget.ViewPager;

import com.financail.moneymanagement.CoinViewDetail;
import com.financail.moneymanagement.R;


import java.util.List;


public class CoinAdapter extends RecyclerView.Adapter<CoinAdapter.ViewHolder> {
    private List<Coin> coinList;
    private Activity context;
    private ViewPager mViewPager;
    private WebView webView;

    @SuppressLint("NotifyDataSetChanged")
    public CoinAdapter(Activity contextN, List<Coin> coinList){
        this.context = contextN;
        this.coinList = coinList;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.list_row_coin, parent, false);
        return new ViewHolder(view);
    }

    public String[] mColors = {"#2ebd84", "#f5465c"};

    @SuppressLint({"ResourceAsColor", "SetTextI18n"})
    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        Coin coin = coinList.get(position);

        holder.name.setText(coin.getName());
        holder.price_d.setText(String.valueOf(coin.getPrice_d()));
        holder.price_v.setText(String.valueOf(coin.getPrice_v()));

        float coinprice24 = Float.parseFloat(coin.getPrice_24());
        if(coinprice24 > 0){
            holder.price_24h.setText("+"+String.valueOf(coin.getPrice_24())+"%");
            holder.price_24h.setBackgroundColor(Color.parseColor(mColors[0]));
        }else {
            holder.price_24h.setText(String.valueOf(coin.getPrice_24())+"%");
            holder.price_24h.setBackgroundColor(Color.parseColor(mColors[1]));
        }
    }

    @Override
    public int getItemCount() {
        return coinList.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder{
        private TextView name, price_d, price_v, price_24h, coinView;
        @SuppressLint("CutPasteId")
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            name = itemView.findViewById(R.id.item_coin_name_mm);
            price_d = itemView.findViewById(R.id.item_coin_price_mm);
            price_v = itemView.findViewById(R.id.item_coin_price_V);
            price_24h = itemView.findViewById(R.id.item_coin_percent_mm);

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
