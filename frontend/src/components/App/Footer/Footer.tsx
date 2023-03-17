import "./Footer.css"

export const Footer = () => {
  return (
    <footer className="footer">
      <div className="container footer__content">
        <h3>Massor<br/> Av MASar</h3>
        <img className="footer__content-logo"src="../public/squareLogo.png" alt="mas logo" />
      </div>
      <ul className="footer__links">
        <li><i className="fa-brands fa-square-github"></i></li>
        <li><i className="fa-brands fa-linkedin"></i></li>
        <li><i className="fa-brands fa-square-facebook"></i></li>
      </ul>
    </footer>
  )
}
