package com.onetouch.onetouch;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;

public class InicioActivity extends AppCompatActivity {

    ImageButton mundoCosmetico;
    ImageButton mundoMagico;
    ImageButton mundoShoppers;
    ImageButton mundoShoppersOnLine;

    ImageButton mundoMayorista;
    ImageButton beautyPro;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_inicio);

        mundoCosmetico = (ImageButton) findViewById(R.id.ibMundoCosmetico);
        mundoMagico = (ImageButton) findViewById(R.id.ibMundoMagico);
        mundoShoppers = (ImageButton) findViewById(R.id.ibShoppers);
        mundoShoppersOnLine = (ImageButton) findViewById(R.id.ibShoppersOnLine);

        mundoMayorista = (ImageButton) findViewById(R.id.ibMundoMayorista);
        beautyPro = (ImageButton) findViewById(R.id.ibBeautyPro);

        mundoCosmetico.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(InicioActivity.this, SegundaActivity.class);
                intent.putExtra("empresa", "Mundo Cosmetico");
                InicioActivity.this.startActivity(intent);
            }
        });

        mundoMagico.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(InicioActivity.this, SegundaActivity.class);
                intent.putExtra("empresa", "Mundo Mágico");
                InicioActivity.this.startActivity(intent);
            }
        });

        mundoShoppers.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(InicioActivity.this, SegundaActivity.class);
                intent.putExtra("empresa", "Shoppers");
                InicioActivity.this.startActivity(intent);
            }
        });

        mundoMayorista.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(InicioActivity.this, SegundaActivity.class);
                intent.putExtra("empresa", "Mundo Mayorista");
                InicioActivity.this.startActivity(intent);
            }
        });

        beautyPro.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(InicioActivity.this, SegundaActivity.class);
                intent.putExtra("empresa", "Beauty Pro");
                InicioActivity.this.startActivity(intent);
            }
        });

        mundoShoppersOnLine.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(InicioActivity.this, SegundaActivity.class);
                intent.putExtra("empresa", "Shoppers");
                InicioActivity.this.startActivity(intent);
            }
        });
    }
}
