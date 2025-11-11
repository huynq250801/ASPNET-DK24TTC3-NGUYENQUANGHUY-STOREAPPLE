function qs(s) { return document.querySelector(s) }

// Cart drawer toggle
function toggleCart() {
    const cart = qs('#cart');
    const bg = qs('#backdrop');
    const isClosed = cart.style.transform.includes('100%');
    cart.style.transform = isClosed ? 'translateX(0)' : 'translateX(100%)';
    bg.style.opacity = isClosed ? 1 : 0;
    bg.style.pointerEvents = isClosed ? 'auto' : 'none';
}

// Thêm sản phẩm vào giỏ (demo)
function addToCart(name, price) {
    const wrap = qs('#cartItems');
    const item = document.createElement('div');
    item.style.marginBottom = '12px';
    item.innerHTML = `
    <div style="display:flex;justify-content:space-between">
      <span>${name}</span>
      <strong>${price.toLocaleString('vi-VN')}₫</strong>
    </div>
  `;
    wrap.appendChild(item);
    toggleCart();
}
