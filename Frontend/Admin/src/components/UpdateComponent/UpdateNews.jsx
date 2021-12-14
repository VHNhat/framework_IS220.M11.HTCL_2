/* eslint-disable jsx-a11y/alt-text */
import { Fade, Paper } from '@mui/material';
import { useSnackbar } from 'notistack';
import React, { useContext, useEffect, useState } from 'react';
import { getNewId, updateNews } from '../../app/ApiResult';
import { context } from '../../app/Context';
import Product from '../Product';
import './stylesUpdateComponent/UpdateNews.scss';
function UpdateNews(props) {  
  const { id } = props;
  const Context = useContext(context);
  const { setBodyAdmin, setFillerAdmin } = Context;
  const [valueData, setValueData] = useState({
    Id: '',
    Title: '',
    Thumbnail: '',
    Content: '',
  });
  // eslint-disable-next-line react-hooks/exhaustive-deps
  useEffect( async ()=>{
    const New= await getNewId(id,'/news');
    if(New)
   setValueData({
     ...valueData,
     Id:New?.Id,
     Title: New?.Title,
     Thumbnail: New?.Thumbnail,
     Content: New?.Content,
   })


  // eslint-disable-next-line react-hooks/exhaustive-deps
  },[id])

  function Prev() {
    setBodyAdmin(<Product />);
    setFillerAdmin('PRODUCT')
  }
  const handleChange = (event) => {
    setValueData({ ...valueData, [event.target.name]: event.target.value });
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
  const HandleUpload = async () => {
    const res = await updateNews(valueData)
   
    if (res?.success) {
      enqueueSnackbar('Tải lên thành công', { variant: 'success' });
    } else {
      enqueueSnackbar('Tải thất bại', { variant: 'error' });
    }
  };
  return (
    <div className='UpdateNews'>
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
      <h2 className='text-center pt-2'>Chỉnh sửa báo </h2>
      <p  style={{width:'60%',margin:'0 auto'}}>Mã báo:{id}</p>
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

     

        <input type='file' id='inputFile' onChange={HandleChange} />
        <label className='inputFileLabel label--input inputData ' htmlFor='inputFile'>
          <div className='box_input'>
            <p className='text-center textUpload '>Hình ảnh mô tả</p>
            {image ? <img className='img_preview' src={image.preview} />: 
                valueData?.Thumbnail &&<img className='img_preview' src={valueData?.Thumbnail} />}
            <i className='fad fa-plus-circle iconUpLoad'></i>
          </div>
        </label>
        <div className='form-floating inputData'>
          <textarea
            className='form-control'
            placeholder='Leave a comment here'
            id='floatingTextarea2'
            name='Content'
            color='warning'
            value={valueData.Content}
            onChange={handleChange}
            style={{ height: '200px' }}></textarea>
          <label className="Content" for='floatingTextarea2'>Nội dung</label>
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

export default UpdateNews;
