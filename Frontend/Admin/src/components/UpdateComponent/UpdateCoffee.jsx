/* eslint-disable jsx-a11y/alt-text */
import Checkbox from '@mui/material/Checkbox';
import Fade from '@mui/material/Grow';
import Paper from '@mui/material/Paper';
import { useSnackbar } from 'notistack';
import React, { useContext, useState } from 'react';
import { context } from '../../app/Context';
import Product from '../Product/index';
import './stylesUpdateComponent/UpdateCoffee.scss';
function UpdateCoffee(props) {
  const Context = useContext(context);
  const { setBodyAdmin, setFillerAdmin,TypeDataPro } = Context;
  console.log(TypeDataPro)
  const [valueData, setValueData] = useState({
    Id: '',
    Title: '',
    Photo: '',
    Description: '',
    Price: '',
  });

  const { id } = props;
  function Prev() {
    setBodyAdmin(<Product />);
    setFillerAdmin('PRODUCT');
  }

  const handleChange = (event) => {
    setValueData({ ...valueData, [event.target.name]: [event.target.value] });
  };
  const { enqueueSnackbar } = useSnackbar();
  const [image, setImage] = useState();
  const [urlImage, setUrlimage] = useState(undefined);
  var HandleChange = (e) => {
    const file = e.target?.files[0];
    if (file) {
      const fileType = file['type'];
      const validImageTypes = ['image/gif', 'image/jpeg', 'image/png'];
      if (!validImageTypes.includes(fileType)) {
        enqueueSnackbar('Sai định dạng', { variant: 'error' });
        setUrlimage(undefined);
      } else {
        if (file) {
          file.preview = URL.createObjectURL(file);
          setImage(file);
        }
      }
    }
  };
  // const HandleUpload = () => {
  //   if (image) {
  //     enqueueSnackbar('Tải lên thành công', { variant: 'success' });
  //   } else {
  //     enqueueSnackbar('Hãy chọn tệp tin', { variant: 'warning' });
  //   }
  // };
  return (
    <div className='UpdateCoffee'>
      <Fade in={true} timeout={200} style={{ height: '100%' }}>
        <Paper>
          <button
            type='button'
            className='btn btn-success d-flex gap-2'
            onClick={() => Prev()}>
            <i
              style={{ fontSize: '1.5rem' }}
              className='fad fa-chevron-circle-left'></i>
            <p className> Quay lại</p>
          </button>
          <h2 className='text-center'>Cập nhật sản phẩm </h2>
          <p  style={{width:'80%',margin:'0 auto'}}>Mã sản phẩm (Coffee):{id}</p>
          <div className='dataUpdate'>
            <div className='form-floating mb-3 inputData'>
              <input
                type='text'
                className='form-control '
                name='Title'
                color='warning'
                value={valueData.Title}
                onChange={handleChange}
              />
              <label htmlFor='floatingInput'>Tiêu đề</label>
            </div>

            <div className='form-floating mb-3 inputData'>
              <input
                type='text'
                className='form-control'
                name='Price'
                color='warning'
                value={valueData.Price}
                onChange={handleChange}
              />
              <label htmlFor='floatingInput'>Giá</label>
            </div>

            <input type='file' id='inputFile' onChange={HandleChange} />
     
            
            <label className='inputFileLabel inputData ' htmlFor='inputFile'>
            <span>Giữ lại hình ảnh cũ</span> <Checkbox defaultChecked style={{position:'absolute',marginTop:'-10px',zIndex:'999'}}/>
              <div className='box_input'>
                <p className='text-center textUpload '>Hình ảnh mô tả</p>
                {image && <img className='img_preview' src={image.preview} />}
                <i className='fad fa-plus-circle iconUpLoad'></i>
              </div>
            </label>
        
            <div className='form-floating inputData' style={{marginTop:'30px'}}>
              <textarea
                className='form-control'
                placeholder='Leave a comment here'
                id='floatingTextarea2'
                name='Description'
                color='warning'
                value={valueData.Description}
                onChange={handleChange}
                style={{ height: '200px' }}></textarea>
              <label className='description' htmlFor='floatingTextarea2'>
                Nội dung
              </label>
            </div>
          </div>
        </Paper>
      </Fade>
    </div>
  );
}

export default UpdateCoffee;
