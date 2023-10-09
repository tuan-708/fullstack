package com.financail.moneymanagement;

import android.Manifest;
import android.app.Activity;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.Bundle;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentPagerAdapter;
import androidx.fragment.app.FragmentStatePagerAdapter;
import androidx.viewpager.widget.ViewPager;

import android.os.Handler;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.SearchView;
import android.widget.Toast;

import com.financail.moneymanagement.login.LoginActivity;
import com.financail.moneymanagement.view_coin.Coin_Favourite;
import com.financail.moneymanagement.view_coin.Coin_Price_Decrease;
import com.financail.moneymanagement.view_coin.Coin_Price_Increase;
import com.financail.moneymanagement.view_coin.Coin_Top;
import com.google.android.material.tabs.TabLayout;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link HomeFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class HomeFragment extends Fragment {
    private TabLayout mTabLayout;
    private ViewPager mViewPager;
    private ImageView icon_hotline, icon_profile;
    private SearchView searchView;
    private ListView listView, listOption;
    ArrayAdapter<String> arrayAdapter, arrayAdapter1;
    private FirebaseAuth mFirebaseAuth;

    String[] namelist = {"BTCUSDT", "ETHUSDT", "BNBUSDT", "BCCUSDT", "NEOUSDT", "LTCUSDT", "QTUMUSDT", "ADAUSDT", "XRPUSDT", "EOSUSDT", "TUSDUSDT", "IOTAUSDT", "XLMUSDT", "ONTUSDT", "TRXUSDT", "ETCUSDT", "ICXUSDT", "VENUSDT", "NULSUSDT", "VETUSDT", "PAXUSDT", "BCHABCUSDT", "BCHSVUSDT", "USDCUSDT", "LINKUSDT", "WAVESUSDT", "BTTUSDT", "USDSUSDT", "ONGUSDT", "HOTUSDT", "ZILUSDT", "ZRXUSDT", "FETUSDT", "BATUSDT", "XMRUSDT", "ZECUSDT", "IOSTUSDT", "CELRUSDT", "DASHUSDT", "NANOUSDT", "OMGUSDT", "THETAUSDT", "ENJUSDT", "MITHUSDT", "MATICUSDT", "ATOMUSDT", "TFUELUSDT", "ONEUSDT", "FTMUSDT", "ALGOUSDT", "USDSBUSDT", "GTOUSDT", "ERDUSDT", "DOGEUSDT", "DUSKUSDT", "ANKRUSDT", "WINUSDT", "COSUSDT", "NPXSUSDT", "COCOSUSDT", "MTLUSDT", "TOMOUSDT", "PERLUSDT", "DENTUSDT", "MFTUSDT", "KEYUSDT", "STORMUSDT", "DOCKUSDT", "WANUSDT", "FUNUSDT", "CVCUSDT", "CHZUSDT", "BANDUSDT", "BUSDUSDT", "BEAMUSDT", "XTZUSDT", "RENUSDT", "RVNUSDT", "HCUSDT", "HBARUSDT", "NKNUSDT", "STXUSDT", "KAVAUSDT", "ARPAUSDT", "IOTXUSDT", "RLCUSDT", "MCOUSDT", "CTXCUSDT", "BCHUSDT", "TROYUSDT", "VITEUSDT", "FTTUSDT", "EURUSDT", "OGNUSDT", "DREPUSDT", "BULLUSDT", "BEARUSDT", "ETHBULLUSDT", "ETHBEARUSDT", "TCTUSDT", "WRXUSDT", "BTSUSDT", "LSKUSDT", "BNTUSDT", "LTOUSDT", "EOSBULLUSDT", "EOSBEARUSDT", "XRPBULLUSDT", "XRPBEARUSDT", "STRATUSDT", "AIONUSDT", "MBLUSDT", "COTIUSDT", "BNBBULLUSDT", "BNBBEARUSDT", "STPTUSDT", "WTCUSDT", "DATAUSDT", "XZCUSDT", "SOLUSDT", "CTSIUSDT", "HIVEUSDT", "CHRUSDT", "BTCUPUSDT", "BTCDOWNUSDT", "GXSUSDT", "ARDRUSDT", "LENDUSDT", "MDTUSDT", "STMXUSDT", "KNCUSDT", "REPUSDT", "LRCUSDT", "PNTUSDT", "COMPUSDT", "BKRWUSDT", "SCUSDT", "ZENUSDT", "SNXUSDT", "ETHUPUSDT", "ETHDOWNUSDT", "ADAUPUSDT", "ADADOWNUSDT", "LINKUPUSDT", "LINKDOWNUSDT", "VTHOUSDT", "DGBUSDT", "GBPUSDT", "SXPUSDT", "MKRUSDT", "DAIUSDT", "DCRUSDT", "STORJUSDT", "BNBUPUSDT", "BNBDOWNUSDT", "XTZUPUSDT", "XTZDOWNUSDT", "MANAUSDT", "AUDUSDT", "YFIUSDT", "BALUSDT", "BLZUSDT", "IRISUSDT", "KMDUSDT", "JSTUSDT", "SRMUSDT", "ANTUSDT", "CRVUSDT", "SANDUSDT", "OCEANUSDT", "NMRUSDT", "DOTUSDT", "LUNAUSDT", "RSRUSDT", "PAXGUSDT", "WNXMUSDT", "TRBUSDT", "BZRXUSDT", "SUSHIUSDT", "YFIIUSDT", "KSMUSDT", "EGLDUSDT", "DIAUSDT", "RUNEUSDT", "FIOUSDT", "UMAUSDT", "EOSUPUSDT", "EOSDOWNUSDT", "TRXUPUSDT", "TRXDOWNUSDT", "XRPUPUSDT", "XRPDOWNUSDT", "DOTUPUSDT", "DOTDOWNUSDT", "BELUSDT", "WINGUSDT", "LTCUPUSDT", "LTCDOWNUSDT", "UNIUSDT", "NBSUSDT", "OXTUSDT", "SUNUSDT", "AVAXUSDT", "HNTUSDT", "FLMUSDT", "UNIUPUSDT", "UNIDOWNUSDT", "ORNUSDT", "UTKUSDT", "XVSUSDT", "ALPHAUSDT", "AAVEUSDT", "NEARUSDT", "SXPUPUSDT", "SXPDOWNUSDT", "FILUSDT", "FILUPUSDT", "FILDOWNUSDT", "YFIUPUSDT", "YFIDOWNUSDT", "INJUSDT", "AUDIOUSDT", "CTKUSDT", "BCHUPUSDT", "BCHDOWNUSDT", "AKROUSDT", "AXSUSDT", "HARDUSDT", "DNTUSDT", "STRAXUSDT", "UNFIUSDT", "ROSEUSDT", "AVAUSDT", "XEMUSDT", "AAVEUPUSDT", "AAVEDOWNUSDT", "SKLUSDT", "SUSDUSDT", "SUSHIUPUSDT", "SUSHIDOWNUSDT", "XLMUPUSDT", "XLMDOWNUSDT", "GRTUSDT", "JUVUSDT", "PSGUSDT", "1INCHUSDT", "REEFUSDT", "OGUSDT", "ATMUSDT", "ASRUSDT", "CELOUSDT", "RIFUSDT", "BTCSTUSDT", "TRUUSDT", "CKBUSDT", "TWTUSDT", "FIROUSDT", "LITUSDT", "SFPUSDT", "DODOUSDT", "CAKEUSDT", "ACMUSDT", "BADGERUSDT", "FISUSDT", "OMUSDT", "PONDUSDT", "DEGOUSDT", "ALICEUSDT", "LINAUSDT", "PERPUSDT", "RAMPUSDT", "SUPERUSDT", "CFXUSDT", "EPSUSDT", "AUTOUSDT", "TKOUSDT", "PUNDIXUSDT", "TLMUSDT", "1INCHUPUSDT", "1INCHDOWNUSDT", "BTGUSDT", "MIRUSDT", "BARUSDT", "FORTHUSDT", "BAKEUSDT", "BURGERUSDT", "SLPUSDT", "SHIBUSDT", "ICPUSDT", "ARUSDT", "POLSUSDT", "MDXUSDT", "MASKUSDT", "LPTUSDT", "NUUSDT", "XVGUSDT", "ATAUSDT", "GTCUSDT", "TORNUSDT", "KEEPUSDT", "ERNUSDT", "KLAYUSDT", "PHAUSDT", "BONDUSDT", "MLNUSDT", "DEXEUSDT", "C98USDT", "CLVUSDT", "QNTUSDT", "FLOWUSDT", "TVKUSDT", "MINAUSDT", "RAYUSDT", "FARMUSDT", "ALPACAUSDT", "QUICKUSDT", "MBOXUSDT", "FORUSDT", "REQUSDT", "GHSTUSDT", "WAXPUSDT", "TRIBEUSDT", "GNOUSDT", "XECUSDT", "ELFUSDT", "DYDXUSDT", "POLYUSDT", "IDEXUSDT", "VIDTUSDT", "USDPUSDT", "GALAUSDT", "ILVUSDT", "YGGUSDT", "SYSUSDT", "DFUSDT", "FIDAUSDT", "FRONTUSDT", "CVPUSDT", "AGLDUSDT", "RADUSDT", "BETAUSDT", "RAREUSDT", "LAZIOUSDT", "CHESSUSDT", "ADXUSDT", "AUCTIONUSDT", "DARUSDT", "BNXUSDT", "RGTUSDT", "MOVRUSDT", "CITYUSDT", "ENSUSDT", "KP3RUSDT", "QIUSDT", "PORTOUSDT", "POWRUSDT", "VGXUSDT", "JASMYUSDT", "AMPUSDT", "PLAUSDT", "PYRUSDT", "RNDRUSDT", "ALCXUSDT", "SANTOSUSDT", "MCUSDT", "ANYUSDT", "BICOUSDT", "FLUXUSDT", "FXSUSDT", "VOXELUSDT", "HIGHUSDT", "CVXUSDT", "PEOPLEUSDT", "OOKIUSDT", "SPELLUSDT", "USTUSDT", "JOEUSDT", "ACHUSDT", "IMXUSDT", "GLMRUSDT", "LOKAUSDT", "SCRTUSDT", "API3USDT", "BTTCUSDT", "ACAUSDT", "ANCUSDT", "XNOUSDT", "WOOUSDT", "ALPINEUSDT", "TUSDT", "ASTRUSDT", "NBTUSDT", "GMTUSDT", "KDAUSDT", "APEUSDT", "BSWUSDT", "BIFIUSDT", "MULTIUSDT", "STEEMUSDT", "MOBUSDT", "NEXOUSDT", "REIUSDT", "GALUSDT", "LDOUSDT", "EPXUSDT", "OPUSDT", "LEVERUSDT", "STGUSDT", "LUNCUSDT", "GMXUSDT", "NEBLUSDT", "POLYXUSDT", "APTUSDT", "OSMOUSDT", "HFTUSDT"};
    String[] optionList = {"Setting", "Logout"};

    public HomeFragment() {
        // Required empty public constructor
    }

    public static HomeFragment newInstance(String param1, String param2) {
        HomeFragment fragment = new HomeFragment();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_home, container, false);
        mTabLayout = (TabLayout)view.findViewById(R.id.table_layout);
        mViewPager = (ViewPager)view.findViewById(R.id.view_pager);
        icon_hotline = (ImageView) view.findViewById(R.id.icon_hotline);
        listOption = view.findViewById(R.id.list_coin_search1);

        searchView = view.findViewById(R.id.icon_search_coin);
        icon_profile = view.findViewById(R.id.icon_profile);
        icon_profile.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(listOption.getVisibility() == View.VISIBLE){
                    listOption.setVisibility(View.INVISIBLE);
                    return;
                }
                listOption.setVisibility(View.VISIBLE);
            }
        });

        arrayAdapter1 = new ArrayAdapter<String>(getContext(), R.layout.customlayout, optionList);
        listOption.setAdapter(arrayAdapter1);
        listOption.setOnItemClickListener(new AdapterView.OnItemClickListener(){
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if(position == 1){
                    mFirebaseAuth = FirebaseAuth.getInstance();
                    FirebaseUser mFirebaseUser = mFirebaseAuth.getCurrentUser();
                    FirebaseAuth.getInstance().signOut();
                    Intent intent = new Intent(getContext(), LoginActivity.class);
                    getActivity().startActivity(intent);
                }
        }});


        listView = view.findViewById(R.id.list_coin_search);
        arrayAdapter = new ArrayAdapter<String>(getContext(), android.R.layout.simple_list_item_1, android.R.id.text1, namelist);
        listView.setAdapter(arrayAdapter);

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Intent itent = new Intent(getActivity(), CoinViewDetail.class);
                itent.putExtra("symbol", String.valueOf(parent.getItemAtPosition(position)));
                Log.d("ssss", String.valueOf(parent.getItemAtPosition(position)));
                getActivity().startActivity(itent);
            }
        });

        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                arrayAdapter.getFilter().filter(query);
                listView.setVisibility(View.VISIBLE);
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                if(newText.equals("")){
                    listView.setVisibility(View.INVISIBLE);
                    return false;
                }
                arrayAdapter.getFilter().filter(newText);
                listView.setVisibility(View.VISIBLE);
                return false;
            }
        });

        icon_hotline.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String number = "0828782000";
                if (number.trim().length() > 0) {

                    if (ContextCompat.checkSelfPermission(getContext(),
                            Manifest.permission.CALL_PHONE) != PackageManager.PERMISSION_GRANTED) {
                        ActivityCompat.requestPermissions((Activity) getContext(),
                                new String[]{Manifest.permission.CALL_PHONE}, 1);
                    } else {
                        String dial = "tel:" + number;
                        startActivity(new Intent(Intent.ACTION_CALL, Uri.parse(dial)));
                    }

                } else {
                    Toast.makeText(getContext(), "Enter Phone Number", Toast.LENGTH_SHORT).show();
                }
            }
        });

        return view;
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        setupViewPager(mViewPager);
        mTabLayout.setupWithViewPager(mViewPager);

        mTabLayout.setOnTabSelectedListener(new TabLayout.OnTabSelectedListener() {
            @Override
            public void onTabSelected(TabLayout.Tab tab) {
                if(tab.getPosition() == 0){
                    new Coin_Top();
                }
                if(tab.getPosition() == 1){
                    new Coin_Price_Decrease();
                }
                if(tab.getPosition() == 2){
                    new Coin_Price_Increase();
                }
                if(tab.getPosition() == 3){
                    new Coin_Favourite();
                }
            }

            @Override
            public void onTabUnselected(TabLayout.Tab tab) {

            }

            @Override
            public void onTabReselected(TabLayout.Tab tab) {

            }
        });
    }

    private void setupViewPager(ViewPager viewPager) {
        ViewCoinListAdapter viewPagerAdapter = new ViewCoinListAdapter(getChildFragmentManager());

        viewPager.setAdapter(viewPagerAdapter);
    }

    private static class ViewCoinListAdapter extends FragmentPagerAdapter {

        public ViewCoinListAdapter(FragmentManager fragmentManager) {
            super(fragmentManager);
        }

        @Override
        public Fragment getItem(int position) {
            if(position == 0) return new Coin_Top();
            if(position == 1) return new Coin_Price_Increase();
            if(position == 2) return new Coin_Price_Decrease();
            if(position == 3) return new Coin_Favourite();
            throw new IllegalStateException("Position is unexpectedly " + position);
        }

        @Override
        public int getCount() {
            return 4;
        }

        @Override
        public CharSequence getPageTitle(int position) {
            if(position == 0) return "Coin top";
            if(position == 1) return "Coin up";
            if(position == 2) return "Coin down";
            if(position == 3) return "Coin favourite";
            throw new IllegalStateException("Position is unexpectedly " + position);
        }
    }
}