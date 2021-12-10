import { Fade, Paper } from '@mui/material';
import { useSnackbar } from 'notistack';
import React, { useContext, useState } from 'react';
import ProductType from './../../Product/ProductType/index.';
import { context } from './../../../app/Context';
import './UpdateProductType.scss'
import { addProType } from '../../../app/ApiResult';
function AddProductType(props) {
  const Context = useContext(context);
  const { setBodyAdmin, setFillerAdmin } = Context;
  const [valueData, setValueData] = useState({
    Name: '',
    Photo: '',
    Description: '',
  });
  function Prev() {
    setBodyAdmin(<ProductType />);
    setFillerAdmin('PRODUCTTYPE')
  }
  const handleChange = (event) => {
    setValueData({ ...valueData, [event.target.name]: event.target.value });
  };
  const { enqueueSnackbar } = useSnackbar();
  const [image, setImage] = useState();
  const [urlImage, setUrlimage] = useState(undefined);
  var HandleChange = (e) => {
    const file = e.target?.files[0];
    console.log(urlImage)
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

  const HandleUpload = async () => {
    console.log(valueData)
    const res = await addProType(valueData);
    if (res?.success) {
      enqueueSnackbar('Tải lên thành công', { variant: 'success' });
    } else {
      enqueueSnackbar('Tải lên thất bại', { variant: 'error' });
    }
  };
  return (
    <div className='AddProductType'>
          <Fade in={true} timeout={200} style={{ height: '100%' }}>
        <Paper>
        <button
          style={{width:'fit-content', position:'absolute'}}
            type='button'
            className='btn btn-success d-flex gap-2'
            onClick={() => Prev()}>
            <i
              style={{ fontSize: '1.5rem' }}
              className='fad fa-chevron-circle-left'></i>
            <p className> Quay lại</p>
          </button>
      <h2 className='text-center pt-2'>Cập nhật loại sản phẩm </h2>
      <div className='dataAdd'>
        <div className='form-floating mb-3 inputData'>
          <input
            type='text'
            className='form-control '
            name='Name'
            color='warning'
            value={valueData.Name}
            onChange={handleChange}
          />
          <label htmlFor='floatingInput'>Tiêu đề</label>
        </div>

     

        <input type='file' id='inputFile' onChange={HandleChange} />
        <label className='inputFileLabel label--input inputData ' htmlFor='inputFile'>
          <div className='box_input'>
            <p className='text-center textUpload '>Hình ảnh mô tả</p>
            {image ? <img className='img_preview' src={image.preview} />: 
                valueData?.Photo&&<img className='img_preview' src={valueData?.Photo} />}
            <i className='fad fa-plus-circle iconUpLoad'></i>
          </div>
        </label>
        <div className='form-floating inputData'>
          <textarea
            className='form-control'
            placeholder='Leave a comment here'
            id='floatingTextarea2'
            name='Description'
            color='warning'
            value={valueData.Description}
            onChange={handleChange}
            style={{ height: '200px' }}></textarea>
          <label className="description" for='floatingTextarea2'>Nội dung</label>
        </div>
        
        <div className="button__submit">
              <button type="submit" className='btn btn-success inputData' style={{minWidth:"200px"}} onClick={HandleUpload}>Cập nhật</button>
            </div>
      </div>
      </Paper>
      </Fade>
    </div>
  );
}

export default AddProductType;
