const byteMessageType = {
    Error: 0,
    Success: 1,
    Info: 2,
    Warning: 3
}

const stringMessageType = {
    Error: 'Error',
    Success: 'Success',
    Info: 'Info',
    Warning: 'Warning'
}

function DisplayToastMessage(resultType, resultMessage) {
    switch (resultType) {
        case byteMessageType.Error:
        case stringMessageType.Error:
            toastr.error(resultMessage);
            break;
        case byteMessageType.Success:
        case stringMessageType.Success:
            toastr.success(resultMessage);
            break;
        case byteMessageType.Information:
        case stringMessageType.Information:
            toastr.info(resultMessage);
            break;
        case byteMessageType.Warning:
        case stringMessageType.Warning:
            toastr.warning(resultMessage);
            break;


    }
}