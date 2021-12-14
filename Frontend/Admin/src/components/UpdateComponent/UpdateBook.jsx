/* eslint-disable jsx-a11y/alt-text */
import { Checkbox } from '@mui/material';
import Fade from '@mui/material/Grow';
import Paper from '@mui/material/Paper';
import { useSnackbar } from 'notistack';
import React, { useContext, useState } from 'react';
import { context } from '../../app/Context';
import Product from '../Product';
import './stylesUpdateComponent/UpdateBook.scss';
import { useEffect } from 'react';
import { getProductId } from './../../app/ApiResult';
function UpdateBook(props) {
  const { id } = props;
  const Context = useContext(context);
  const { setBodyAdmin, setFillerAdmin} = Context;
  const [valueData, setValueData] = useState({
    Id: id ,
    Name: '',
    Photo: '',
    Description: '',
    Author: '',
    Publish: '',
    Price: '',
  });

  // eslint-disable-next-line react-hooks/exhaustive-deps
  useEffect( async ()=>{
    const book= await getProductId(id,'/product');
    if(book)
   setValueData({
     ...valueData,
    Id:book.Id,
    Name: book?.Name,
    Photo: book?.Photo,
    Description:book?.Description,
    Author: book?.Author,
    Publish:book?.Publish,
    Price: book?.Price
   })


  // eslint-disable-next-line react-hooks/exhaustive-deps
  },[id])
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

  const HandleUpload = () => {
    if (image) {
      enqueueSnackbar('Tải lên thành công', { variant: 'success' });
    } else {
      enqueueSnackbar('Hãy chọn tệp tin', { variant: 'warning' });
    }
  };
  return (
    <div className='UpdateBook'>
       <Fade in={true} timeout={200} style={{ height: '100%' }}>
        <Paper>
          <button
          style={{width:'fit-content',position:'absolute'}}
            type='button'
            className='btn btn-success d-flex gap-2'
            onClick={() => Prev()}>
            <i
              style={{ fontSize: '1.5rem' }}
              className='fad fa-chevron-circle-left'></i>
            <p className> Quay lại</p>
          </button>
          <h2 className='text-center pt-2 '>Cập nhật sản phẩm </h2>
          <p  style={{width:'80%',margin:'0 auto'}}>Mã sản phẩm (Book):{id}</p>
          <div className='dataUpdate'>
          <div className='data--short_text'>
            <div className='form-floating mb-3 inputData'>
              <input
                type='text'
                className='form-control '
                name='Name'
                color='warning'
                value={valueData?.Name}
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
                value= {valueData?.Price}
                onChange={handleChange}
              />
             
              <label htmlFor='floatingInput'>Giá</label>
            </div>
            <div className='form-floating mb-3 inputData'>
              <input
                type='text'
                className='form-control '
                name='Author'
                color='warning'
                value={valueData?.Author}
                onChange={handleChange}
              />
              <label htmlFor='floatingInput'>Author</label>
            </div>
            <div className='form-floating mb-3 inputData'>
              <input
                type='text'
                className='form-control '
                name='Publish'
                color='warning'
                value={valueData?.Publish}
                onChange={handleChange}
              />
              <label htmlFor='floatingInput'>Publish</label>
            </div>
            </div>
            <div className='data--large_text'>
            <input type='file' id='inputFile' onChange={HandleChange} />
     
            
            <label className='inputFileLabel inputData ' htmlFor='inputFile'>
            <span>Giữ lại hình ảnh cũ <Checkbox  defaultChecked /></span> 
              <div className='box_input'>
                <p className='text-center textUpload '>Hình ảnh mô tả</p>
                {image ? <img className='img_preview' src={image.preview} />: 
                valueData?.Photo&&<img className='img_preview' src={valueData?.Photo} />}
                <i className='fad fa-plus-circle iconUpLoad'></i>
              </div>
            </label>
        
            <div className='form-floating inputData' >
              <textarea
                className='form-control'
                placeholder='Leave a comment here'
                id='floatingTextarea2'
                name='Description'
                color='warning'
                value={valueData.Description}
                onChange={handleChange}
                style={{ height: '170px' }}></textarea>
              <label className='description' htmlFor='floatingTextarea2'>
                Nội dung
              </label>
            </div>
          </div>
          
            <div className="button--submit">
              <button type="submit" className='btn btn-success inputData' style={{minWidth:"200px"}} 
              onClick={HandleUpload}>Cập nhật</button>
            </div>
          </div>
        </Paper>
      </Fade> 
    </div>
  );
}

export default UpdateBook;
