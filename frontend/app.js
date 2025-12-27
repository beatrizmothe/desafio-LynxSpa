const API_URL = "http://localhost:5047";

let products = [];
let cart = [];

async function loadProducts() {
    const res = await fetch(`${API_URL}/products`);
    products = await res.json();
    fillCategories();
    renderProducts(products);
}

function fillCategories() {
    const categories = [...new Set(products.map(p => p.category))];
    const select = document.getElementById("categoryFilter");
    categories.forEach(c => {
        const option = document.createElement("option");
        option.value = c;
        option.textContent = c;
        select.appendChild(option);
    });
}

function renderProducts(list) {
    const container = document.getElementById("products");
    container.innerHTML = "";

    list.forEach(p => {
        const div = document.createElement("div");
        div.className = "product";
        div.innerHTML = `
            <strong>${p.name}</strong><br>
            Categoria: ${p.category}<br>
            Preço: R$ ${(p.priceCents / 100).toFixed(2)}<br>
            <button onclick="addToCart(${p.id})">Adicionar</button>
        `;
        container.appendChild(div);
    });
}

function addToCart(productId) {
    const product = products.find(p => p.id === productId);
    const item = cart.find(i => i.productId === productId);

    if (item) item.quantity++;
    else {
        cart.push({
            productId,
            quantity: 1,
            unitPriceCents: product.priceCents,
            name: product.name
        });
    }
    renderCart();
}

function renderCart() {
    const ul = document.getElementById("cart");
    ul.innerHTML = "";
    let total = 0;

    cart.forEach(i => {
        const subtotal = i.quantity * i.unitPriceCents;
        total += subtotal;

        const li = document.createElement("li");
        li.textContent = `${i.name} - ${i.quantity} x R$ ${(i.unitPriceCents / 100).toFixed(2)}`;
        ul.appendChild(li);
    });

    document.getElementById("total").textContent = (total / 100).toFixed(2);
}

async function finalizarPedido() {
    if (cart.length === 0) {
        alert("Carrinho vazio");
        return;
    }

    const order = {
        customer_Id: 1,
        items: cart.map(i => ({
            product_Id: i.productId,
            quantity: i.quantity
        }))
    };

    const res = await fetch(`${API_URL}/orders`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(order)
    });

    const data = await res.json();
    document.getElementById("orderResult").textContent =
        `Pedido criado com sucesso! Nº ${data.id}`;

    cart = [];
    renderCart();
}

document.getElementById("search").addEventListener("input", applyFilters);
document.getElementById("categoryFilter").addEventListener("change", applyFilters);
document.getElementById("onlyActive").addEventListener("change", applyFilters);

function applyFilters() {
    const search = document.getElementById("search").value.toLowerCase();
    const category = document.getElementById("categoryFilter").value;
    const onlyActive = document.getElementById("onlyActive").checked;

    let filtered = products.filter(p =>
        p.name.toLowerCase().includes(search)
    );

    if (category)
        filtered = filtered.filter(p => p.category === category);

    if (onlyActive)
        filtered = filtered.filter(p => p.active);

    renderProducts(filtered);
}

loadProducts();
