export function Print() {
    for (let el of document.querySelectorAll('.hideWhilePrint')) el.style.display = 'none';
    window.print();
    for (let el of document.querySelectorAll('.hideWhilePrint')) el.style.display = 'block';
}

export function addHandlers() {
    const btn = document.getElementById("PrintBtn");
    btn.addEventListener("click", Print);
}