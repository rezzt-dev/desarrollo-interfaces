import hashlib

def encrypt_md5(text):
    # Convertimos el texto a bytes
    text_bytes = text.encode('utf-8')
    # Creamos un objeto hash MD5
    md5_hash = hashlib.md5()
    # Actualizamos el objeto hash con los bytes del texto
    md5_hash.update(text_bytes)
    # Obtenemos el hash en formato hexadecimal
    return md5_hash.hexdigest()
  
def encrypt_sha256(text):
    # Convertimos el texto a bytes
    text_bytes = text.encode('utf-8')
    # Creamos un objeto hash SHA256
    sha256_hash = hashlib.sha256()
    # Actualizamos el objeto hash con los bytes del texto
    sha256_hash.update(text_bytes)
    # Obtenemos el hash en formato hexadecimal
    return sha256_hash.hexdigest()

def encrypt_sha1(text):
    # Convertimos el texto a bytes
    text_bytes = text.encode('utf-8')
    # Creamos un objeto hash SHA-1
    sha1_hash = hashlib.sha1()
    # Actualizamos el objeto hash con los bytes del texto
    sha1_hash.update(text_bytes)
    # Obtenemos el hash en formato hexadecimal
    return sha1_hash.hexdigest()

def __main():
  # Ejemplo de uso
  texto_original = str(input(" > Introduce la cadena a encriptar usando MD5: "))
  hash_md5 = encrypt_md5(texto_original)
  hash_sha256 = encrypt_sha256(texto_original)
  hash_sha1 = encrypt_sha1(texto_original)
  print(f"Texto original: {texto_original}")
  print(f"Hash MD5: {hash_md5}")
  print(f"Hash SHA256: {hash_sha256}")
  print(f"Hash SHA1: {hash_sha1}")

__main()