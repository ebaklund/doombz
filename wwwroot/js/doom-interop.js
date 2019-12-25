
let _displayCnv;
let _renderCnv;
let _displayCtx;
let _renderCtx;

window._DoomInterop = {
  init: (displayCnv, renderCnv) =>
  {
    _displayCnv = displayCnv;
    _renderCnv = renderCnv;
    _displayCtx = _displayCnv.getContext('2d');
    _renderCtx = _renderCnv.getContext('2d');
  },

  drawLine: (x1, y1, x2, y2) =>
  {
    _renderCtx.lineJoin = 'round';
    _renderCtx.lineWidth = 5;
    _renderCtx.beginPath();
    _renderCtx.moveTo(x1, y1);
    _renderCtx.lineTo(x2, y2);
    _renderCtx.closePath();
    _renderCtx.stroke();
  },

  setContextPropertyValue: (propertyName, propertyValue) =>
  {
    _renderCtx[propertyName] = propertyValue;
  },

  flush: () =>
  {
    _displayCtx.drawImage(_renderCnv, 0, 0);
  //  _renderCtx.clearRect(0, 0, _renderCnv.width, _renderCnv.height);
  }
};
