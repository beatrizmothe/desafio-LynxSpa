const API_URL = "http://localhost:5047";

async function loadOrders() {
    const res = await fetch(`${API_URL}/orders`);
    const orders = await res.json();

    const ul = document.getElementById("orders");
    ul.innerHTML = "";

    orders.forEach(o => {
        const li = document.createElement("li");
        li.textContent = `Pedido #${o.id} - Status: ${o.status}`;
        li.onclick = () => loadOrderDetails(o.id);
        ul.appendChild(li);
    });
}

async function loadOrderDetails(id) {
    const res = await fetch(`${API_URL}/orders/${id}`);
    const order = await res.json();

    document.getElementById("details").textContent =
        JSON.stringify(order, null, 2);
}

loadOrders();
